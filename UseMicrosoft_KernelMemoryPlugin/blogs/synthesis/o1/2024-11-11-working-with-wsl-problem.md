Case 1: 改善 Docker Volume I/O 效能  
- Problem: Docker 容器掛載 Windows 資料夾，IO 效能非常糟糕。  
- RootCause: 容器跨作業系統存取導致需經過 DrvFS 與 9P 協定，多層虛擬化造成性能折損。  
- Resolution: 改將資料擺放在 WSL rootfs (EXT4)，並使用 mklink、Docker volume 等方式維持便利性。  
- Example: 以 Qdrant 為例，將資料從 /mnt/c/ 移至 /opt/docker/ 下，啟動時間從近 40 秒縮短到大約 1.5 秒。  

Case 2: 在同一開發環境下結合 VSCode 與 Linux 工具  
- Problem: 開發流程同時需要 Windows 與 Linux 工具，因在 Windows 下編輯又在 Linux Docker 執行時，頻繁切換、路徑不相容。  
- RootCause: Windows 與 Linux 是不同作業系統，檔案系統與執行模式差異造成溝通成本。  
- Resolution: 使用 VSCode Remote Development，前端於 Windows，實際編譯、測試均在 WSL，保持高 I/O 效率與一致路徑。  
- Example: GitHub Pages 與 Jekyll，在 WSL 下執行 container，可快速預覽與同步編輯 Markdown，多人協作更方便。  

Case 3: 在 Docker 容器使用 GPU/CUDA  
- Problem: 想在本地端以 NVIDIA GPU 執行 AI 相關任務，但在 Windows 下設定 CUDA 相依套件很麻煩，且 Docker Desktop 也不夠彈性。  
- RootCause: Windows 與 Linux 隔閡造成 GPU 虛擬化複雜，驅動層面也容易衝突或需額外設定。  
- Resolution: 於 Windows 安裝 NVIDIA Driver，WSL 下安裝 NVIDIA Container Toolkit，Docker run 時加入 --gpus=all 以啟用 GPU。  
- Example: 在 Docker 內跑 Ollama 或 Stable Diffusion 等模型，只需簡單安裝 ToolKit 即可，不必額外裝 Linux GPU 驅動。  

Case 4: 避免跨系統檔案讀寫的權限和性能問題  
- Problem: 在 Windows 和 Linux 間同時操作檔案，權限模式衝突或丟失，且性能下滑嚴重。  
- RootCause: NTFS 和 EXT4 權限機制大異，DrvFS/9P 導致額外 IO 開銷、檔案通知機制不匹配。  
- Resolution: 儘量集中檔案於同一檔案系統；若需混和使用，採用網路磁碟或 mklink 方式，視為外部掛載協同。  
- Example: GitHub Pages 專案放在 WSL EXT4，而 Windows 端以符號連結查看；避免來回大量更新時腳本失靈。  

Case 5: SSD 掛載配置與 WSL 效能取捨  
- Problem: 使用 WSL 時，虛擬硬碟（VHDX）和實體磁碟等不同配置效能各異，難以選擇。  
- RootCause: WSL2 需透過 Hyper-V 虛擬化，若再跨檔案系統或低階 SSD，立即出現效率瓶頸。  
- Resolution: 投入一顆高階 SSD，以 EXT4 格式專供 WSL；若需簡單管理也可使用獨立 VHDX，同時留意顆粒類型。  
- Example: 作者使用 MLC SSD，掛載為 EXT4 分割區，跑 fio 隨機讀寫可達到甚至超越 Windows 本機檔案系統效能。  