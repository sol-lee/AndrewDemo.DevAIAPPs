## FAQ  
Q1: 為什麼要用 WSL 替代 Docker Desktop？  
A1: 減少授權負擔、提升 I/O 效能，還可更好支援 GPU。  

Q2: 把資料放在哪裡比較快？  
A2: 優先放在 WSL 的 EXT4 檔案系統，避免跨 OS 的 9P 協定延遲。  

Q3: VSCode 如何跨系統操作？  
A3: 透過 Remote Development，將核心動作放在 WSL，UI 保持在 Windows。  

Q4: 如何在 WSL 容器使用 GPU？  
A4: 安裝 NVIDIA 容器工具包並加上 --gpus=all，就能取得 GPU 運算資源。  

Q5: WSL 下 Docker IO 慢是什麼原因？  
A5: 因為 DrvFS 與 9P 協定的轉譯導致大量 I/O 耗損。  

Q6: 可以直接在 WSL 執行 Windows 應用嗎？  
A6: 是，可以在 Linux bash 下呼叫 .exe，由 WSLInterop 處理轉譯。  

Q7: 舊 SSD 能在 WSL 下跑得動嗎？  
A7: 可以，但顆粒類型與掛載方式影響效能，建議用 EXT4。  

Q8: 為什麼作者推薦 .vhdx？  
A8: 獨立磁碟映像檔方便管理，能有效避免雜訊與提升效能。