## 段落1, TL;DR 與背景簡介  
這段主要概述作者重整開發環境的初衷：希望使用 WSL 搭配 VSCode，讓在 Windows 上也能擁有類似原生 Linux 的開發體驗。因覺得 Docker Desktop 過於冗大、授權限制多，且跨系統 IO 效能不彰，作者決定嘗試在 WSL 內直接運行 Docker，再配合 VSCode Remote Development，打造「Windows 展示介面 + Linux 核心執行」的混合模式。整體來說，這篇文章就是記錄作者如何一步步排除障礙，並分享背後的技術細節與黑科技。  

## 段落2, 1. 替換工作環境的動機  
作者因需要在 Docker 上跑 GPU/CUDA 應用，以及解決 Windows 與 Docker 間的 Volume IO 效能問題，決定全面遷移至 WSL。先是拋開 Docker Desktop，以原生 Linux Docker 方式提高執行效率，並透過 WSL 正式使用 Linux 環境。除了效能外，方便長期維護與更省資源的需求，也是推動作者換環境的關鍵。搭配 VSCode 與其他熟悉工具，Windows 與 Linux 可保持高度整合。  

## 段落3, 2. 案例: 容器化的向量資料庫 - Qdrant (概述)  
作者選用 Qdrant 作為向量資料庫案例，因為它經常需要大量 IO 操作。最初若將資料放在 Windows NTFS 下，再掛載給 Docker 使用，性能極差。作者希望透過此案例對比不同檔案放置方式在 WSL 的 IO 效能表現，並記錄實際部署於 Docker 的差異。結果顯示若將 Volume 放在 WSL EXT4，可大幅提升容器啟動與資料庫存取速度。  

## 段落4, 2-1. WSL 磁碟效能 Benchmark  
作者使用 fio 工具測試 Windows ↔ WSL 間的不同存取路徑，發現最理想的情況是 Windows 原生讀寫 NTFS 或 WSL 原生 EXT4；但若 Windows ↔ WSL 跨系統，需經 DrvFS 或 9P 協定，效能下滑非常明顯。測試結果：Windows→Windows 可達 576 MiB/s；WSL→WSL 只有約 200 MiB/s；WD→WSL 或 WSL→WD 跨層會掉到 16~37 MiB/s，顯示多層虛擬化必然導致 IO 大幅損耗。  

## 段落5, 2-2. 測試數據的解讀, 與 WSL 架構  
作者透過架構圖分析 Hyper-V、DrvFS、9P 協定對磁碟效能的影響，指出每多一層轉譯都會大幅降低速度。WSL2 預設使用 ext4.vhdx，在 Windows 檔案系統上虛擬一個磁碟，導致虛擬化開銷。作者也提醒若想最大化效能，可考慮在 WSL 下直接掛載實體磁碟分割區，以 EXT4 原生使用，能避開部分虛擬化損耗。  

## 段落6, 2-3. 實際部署 Qdrant 測試資料庫  
為了驗證 IO 優化成效，作者比較 Qdrant Container 在 NTFS 與 WSL EXT4 的啟動時間。若資料放在 Windows 路徑下，啟動含四萬筆資料庫需 38 秒；改放 WSL EXT4，只要 1.5 秒，差距逾 25 倍。顯示在 Database/容器應用下，大量跨 OS 的 IO 會顯著拖慢啟動或查詢效率。同時也強調若要保留 Windows 使用習慣，可考慮符號連結。  

## 段落7, 2-4. 在 Windows 下掛載 WSL 的資料夾  
作者以 mklink /d 在 Windows 建立符號連結，將 WSL 下 /opt/docker 等目錄對應到 C:\codes\docker，使得 Windows 端仍可用熟悉的檔案總管或開發工具存取資料，同時容器執行時仍享有在 WSL EXT4 下的高速 IO。缺點是若真的在 Windows 端做大量 IO，還是會碰到跨系統效能瓶頸，但日常操作已足夠流暢。  

## 段落8, 2-5. 其他 file system 議題  
此處作者補充 Windows 與 Linux 在權限與特殊檔案功能上有根本不同。Windows 以 ACL 為基礎、Linux 以 chmod/owner 為主，DrvFS 無法完整對應。NTFS 也可能包含多重檔案串流，導致 WSL 看見一些奇怪副檔案。這些細節雖不影響大多數應用，但可能埋下權限與檔案同步的地雷，需特別留意或直接無視。  

## 段落9, 2-6. WSL 掛載額外的 Disk  
作者進行後續深度測試，將實體 SSD 或虛擬磁碟以 EXT4 格式直接掛載 WSL，大幅提升 IO 效能。實驗顯示 MLC SSD 可達到甚至超越原生 Windows NTFS 的水準，而 QLC SSD 效能較差。作者建議若需要在 WSL 處理大量 IO 工作，直接配置專用 SSD，並用 EXT4 格式效果最佳；DrvFS 僅適合少量存取或檔案搬運情境。  

## 段落10, 3. GitHub Pages with Visual Studio Code (總覽)  
針對開發場景，如 GitHub Pages/Jekyll，在 Windows 編寫、Linux Build 會遇到同步問題。作者探討透過 WSL 放置原始碼，加上 Remote Development 來兼顧編輯與執行效能。由於 Jekyll 監聽檔案變化在 Linux 下運行更有效率，不必再經輪詢機制檢查 Windows 系統的變動，也可避免檔案權限設定困擾，整體流程更順暢。  

## 段落11, 3-1. 在 WSL 下執行 Windows CLI / Application  
作者演示在 WSL 下執行 cmd.exe、explorer.exe 等 Windows 應用程式，顯示透過 binfmt_misc 機制，Linux 能識別 .exe 並呼叫 Host Windows 端的執行檔。這種整合讓使用者可在同個 Terminal 同時運行 Windows 與 Linux 指令，不用再多開不同視窗或特別配置路徑，大幅增進開發與操作的彈性。  

## 段落12, 3-2. Visual Studio Code: Remote Development  
這是文中最關鍵的整合：VSCode Remote Development 會在 WSL 端啟動 vscode-server，將檔案存取與編譯等重工作業放在 Linux 內，UI 則在 Windows 顯示。如此一來，文件、程式碼都保持在 Linux 系統中，不再受跨系統 IO 瓶頸所苦。作者展示 Markdown 編輯、Docker Compose、Hot Reload 以及 Port Forward 等功能皆能在此模式下流暢啟用。  

## 段落13, 4. GPU (CUDA) Application (概述)  
作者最初動念便是希望在 Windows 的硬體設備裡，也能於 Linux / Docker 環境使用 GPU 做科學運算與 AI 模型推論。傳統上在 Windows 直接處理 CUDA 相容性、Python 套件相依常令人頭痛，希望藉 WSL 能簡化。Microsoft 為此在 WSL 提供 GPU 虛擬化支援，讓容器可用 --gpus=all 啟動 GPU 加速，大幅降低 CUDA 在 Windows 與 Linux 上切換的難度。  

## 段落14, 4-1. Ollama Docker 的設定步驟  
以 Ollama 為例，作者跟著官方 Docker Hub 指示，在 Windows 安裝 NVIDIA Driver、在 WSL 安裝 NVIDIA Container Toolkit，之後便可在容器內使用 GPU 作推論。測試後發現只要下 nvidia-smi 即可看到顯示卡資訊，並以 docker run --gpus=all 啟動容器。夾帶 CUDA 庫的應用程式因此能如同在 Linux 實機環境般，直接存取 GPU 資源。  

## 段落15, 4-2. WSL + GPU 的冷知識  
作者解析 Microsoft 如何實作 GPU Virtualization：以 /dev/dxg 為核心，由 Windows WDDM 驅動管理實體 GPU，再以虛擬層把資源分配給 WSL。CUDA 與 OpenGL、OpenCL、DirectML 等對應函式庫也被整合到 Linux，讓 WSL 能使用 DirectX Stack 進行 3D 或 AI 運算。作者提到 WSLg 可支援 GUI 應用，能在 Linux 上執行並顯示於 Windows。這些技術背後是多方協定與核心驅動合作的產物。  

## 段落16, 5. 心得  
作者回顧 Microsoft 從「Microsoft ❤️ Linux」口號到實際打造 WSL、VSCode 等整合，許多技術細節都非一朝一夕完成；但如今 Windows 與 Linux 的銜接已近乎無縫，讓 .NET 與容器、AI、大型服務都能輕鬆跨平台。透過 WSL2，不僅實現了在 Windows 上做原生 Linux 開發的可能，也吸收了許多 Linux 開放生態系優勢。整體讓作者深感驚喜，認為這是未來開發模式的大勢所趨。  