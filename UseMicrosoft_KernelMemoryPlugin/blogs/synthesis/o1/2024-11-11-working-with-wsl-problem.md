Case 1: 捨棄 Docker Desktop，改用原生 Linux Docker  
- Problem: 想在 Windows 上執行 Docker，但 Docker Desktop 體積大、授權受限，且用起來資源浪費。  
- RootCause: Docker Desktop 內部仍需與 Windows 溝通，外加授權與功能過剩的問題，額外耗費開發成本與效能。  
- Resolution: 安裝 WSL 與原生 Docker，再讓容器直接跑在 WSL EXT4 檔案系統中，更精簡、效能更好。  
- Example: 與 Qdrant 容器化服務整合，啟動時間與 I/O 效能明顯改善，無需再依賴 Docker Desktop。

Case 2: 解決容器 Volume 的 I/O 效能瓶頸  
- Problem: 將資料庫或 Volume 掛載在 Windows NTFS 下時，透過 Docker & WSL 間的 9P 協定，I/O 速度極慢。  
- RootCause: DrvFS 與 Hyper-V 雙層虛擬化造成大量延遲，導致容器資料讀寫效能嚴重下降。  
- Resolution: 改將 Volume 放置於 WSL 内部的 EXT4，或直接掛載實體磁碟、使用 EXT4。避免跨系統協定的頻繁轉譯。  
- Example: Qdrant 在 Windows 路徑下啟動需近 40 秒，切換到 WSL EXT4 只要 1.5 秒，縮短約 25 倍。

Case 3: 同時滿足 Windows 編輯需求與 Linux 端高速 I/O  
- Problem: 慣用 Windows 編輯器或檔案總管，但容器需要在 Linux 檔案系統才有好效能；若兩邊都要使用，跨系統操作易卡住。  
- RootCause: Windows 與 WSL 有不同檔案系統與權限管理機制，直接 cross-mount 會受 DrvFS 和 9P 協定限制。  
- Resolution: 實際檔案放 WSL EXT4，運行容器時效率最佳；Windows 端以 mklink 做符號連結，讓 Windows 使用者仍然可用熟悉的路徑瀏覽或簡易操作。  
- Example: 在 C:\codes\docker 建立符號連結指到 /opt/docker，原始碼編輯與容器執行都不受大量 I/O 耗損影響。

Case 4: VSCode 與 Linux Toolchain 緊密整合  
- Problem: 在 Windows 上編輯程式，卻要在 Linux 與 Docker 容器調用大量工具、執行測試，頻繁跨系統操作造成延遲。  
- RootCause: IDE 執行在 Windows，檔案、編譯器在 Linux，多次權限與路徑轉譯、I/O 深度呼叫。  
- Resolution: 使用 VSCode Remote Development，於 WSL 內啟動 vscode-server，檔案編譯與測試都在 Linux 進行，Windows 僅負責 UI。  
- Example: 開啟 Markdown 專案，在 WSL 中一鍵 docker compose 建置 Jekyll 網站，VSCode 內建的終端機即為 Linux Bash，避免跨環境切換。

Case 5: 讓容器取得 GPU 資源，實現 AI/CUDA 應用  
- Problem: 需要在容器內跑 GPU/CUDA 模型推論，但 Windows 上安裝 CUDA/顯示卡驅動複雜，往往相容性不佳。  
- RootCause: CUDA 在 Windows 需對應各種版本驅動與工具；Docker Desktop 或其他環境也未必支援 GPU。  
- Resolution: Windows 安裝正確 NVIDIA Driver，WSL 內安裝 NVIDIA Container Toolkit，容器啟動指令加 --gpus=all，即可使用 GPU 虛擬化。  
- Example: 透過 Ollama 容器，在 WSL 裡一鍵啟動大型語言模型推論，nvidia-smi 可檢視 GPU 資源使用狀況，過程順暢無須繁瑣手動配置。