## FAQ  
Q1: 如果想拋開 Docker Desktop，改用 WSL 運行 Docker，有哪些主要優勢？  
A1: 主要有三點好處：第一，安裝與管理更精簡，不必依賴 Docker Desktop；第二，可以直接使用 Linux 原生 Docker，提高容器啟動與磁碟 IO 效率；第三，避免額外授權與資源開銷，整體開發成本更低。  

Q2: 為什麼把資料放在 WSL 的 EXT4 磁碟架構下就能加快容器啟動速度？  
A2: 因為資料直接位於 WSL 的根檔案系統，I/O 不需透過 DrvFS 或 9P 協定轉譯，能大幅縮短載入與初始化時間。例如向量資料庫 Qdrant，就從近 40 秒降至約 1.5 秒。  

Q3: 若仍習慣在 Windows 目錄編輯檔案，該如何避免 IO 效能下降？  
A3: 建議將檔案實際存放在 WSL EXT4 路徑中，再用 mklink 建立符號連結（symbolic link）。這樣在容器執行時仍能享受高速 IO，Windows 端瀏覽或簡單操作亦足夠流暢。  

Q4: VSCode Remote Development 在 WSL 下是如何運作的？  
A4: VSCode 會在 WSL 內安裝並啟動一個 vscode-server，負責編譯、檔案讀寫、除錯等工作。而 Windows 上的 VSCode 只進行 UI 顯示與操作，再透過網路通訊與 server 同步，因此可避免大量跨系統 IO。  

Q5: 怎麼在 WSL 裡使用 GPU 執行 CUDA 應用？  
A5: 安裝正確 Windows NVIDIA Driver，並在 WSL 加裝 NVIDIA Container Toolkit，即可讓容器以 --gpus=all 拿到 GPU 資源。WSL 內部透過 /dev/dxg 虛擬化硬體，無需在 Linux 環境特別安裝 GPU 驅動。