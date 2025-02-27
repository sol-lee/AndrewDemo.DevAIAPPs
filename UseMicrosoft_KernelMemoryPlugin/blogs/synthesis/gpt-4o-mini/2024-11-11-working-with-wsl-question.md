## FAQ
Q1: 為什麼選擇使用 WSL 和 VS Code 來重構開發環境？  
A1: WSL 使得在 Windows 上運行 Linux 應用程式變得更加容易，VS Code 則提供了一個直觀和高效的編輯環境，讓開發工作更具流暢性。這組合可以無縫整合兩個系統的優點。

Q2: 文章中提到的 Docker I/O 效能問題是什麼？  
A2: 在 Windows 環境下運行 Docker 時，掛載 Windows 檔案系統到 Docker 容器中會導致效能顯著下降，這是因為檔案訪問需要經過額外的轉換層，從而導致 I/O 效能不佳。

Q3: 使用 WSL 可以運行 GPU 應用程式嗎？  
A3: 是的，WSL 支援 GPU 虛擬化，使得在 WSL 環境中運行需要 GPU 支持的應用程式變得簡單。使用 NVIDIA 驅動程式和相應的工具可以輕鬆實現。

Q4: 如何改善 WSL 中的 I/O 效能？  
A4: 將檔案存放在 WSL 的本機檔案系統 (如 EXT4) 中，而非 Windows 檔案系統，可以顯著提升 I/O 效能。此外，避免不必要的跨系統檔案存取也很重要。

Q5: VS Code 的遠端開發功能如何幫助開發過程？  
A5: VS Code 的遠端開發功能允許開發者在 WSL 或其他遠端環境中進行開發，這樣可以利用 Linux 的優勢，同時保持 Windows 的使用體驗，提升開發效率。 

Q6: 重整開發環境的主要動機為何？  
A6: 主要動機包括需要更高效的 Docker 環境、改善 I/O 效能、在容器中使用 GPU/CUDA，以及希望在 Windows 和 Linux 之間建立更好的協作。在此背景下，重整開發環境成為必然選擇。

## Case 1: 拋開 Docker Desktop 的需求
- Problem: Docker Desktop 在 Windows 下的功能繁瑣，限制和授權問題困擾使用者。
- RootCause: Docker Desktop 允許的功能範圍和授權限制不符合筆者的需求。
- Resolution: 轉向使用 WSL 來直接運行 Docker，簡化環境設置，減少不必要的組件。
- Example: 在 WSL 環境中直接運行 Docker，實現更乾淨和高效的 Docker 使用體驗。

## Case 2: 改善 I/O 效能
- Problem: 在 Windows 下使用 Docker 時，掛載 I/O 的效能非常低，導致應用運行緩慢。
- RootCause: I/O 操作通過多層轉換，導致效能損失。
- Resolution: 將資料存放在 WSL 的 EXT4 檔案系統中，而非 Windows 檔案系統，直連虛擬磁碟以提高效能。
- Example: 使用 Qdrant 測試資料庫，在 WSL 中直接執行後，啟動時間從 38 秒減少至 1.5 秒。

## Case 3: 整合 GPU 支持
- Problem: 在 Windows 中執行需要 GPU 支持的 AI 應用過程中遇到限制。
- RootCause: 缺乏對 GPU 的原生支持，導致許多模型無法有效運行。
- Resolution: 安裝 NVIDIA 驅動程式和配置 WSL，以利用 GPU 資源運行應用。
- Example: 能夠在 WSL 中運行 ollama 模型，並透過 Docker 技術利用 GPU 資源執行大型模型。

## Case 4: 使用 Visual Studio Code 的整合
- Problem: 開發過程中需要跨 Windows 和 Linux 環境進行操作，效率不高。
- RootCause: 不同作業系統之間的切換造成認知負擔。
- Resolution: 使用 VS Code 的遠端開發功能將開發環境整合到 WSL 環境中。
- Example: 可以直接在 WSL 中使用 VS Code 進行代碼編寫、調試，而無需在 Windows 和 Linux 環境間反覆切換。