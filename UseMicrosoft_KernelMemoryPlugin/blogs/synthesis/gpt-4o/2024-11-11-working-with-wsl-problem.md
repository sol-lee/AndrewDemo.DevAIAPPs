## Case 1: 提升 Docker 容器 IO 效能
- Problem: Docker 在 Windows 上掛載 volume 的 IO 效能低，導致運行緩慢。
- RootCause: Windows 下 Docker 存取 WSL 文件系統需多層轉換，效能損耗嚴重。
- Resolution: 將 Docker volume 挪至 WSL 的 ext4 文件系統中，使用 WSL 提供的原生檔案存取優勢。
- Example: 在 WSL 下配置 Docker，使 volume 存於 ext4，啟動 Qdrant 資料庫可提升 25 倍效能。

## Case 2: VSCode 與 WSL 的深度整合
- Problem: 跨平台開發時，出現效能下降與路徑不一致問題。
- RootCause: Windows 與 Linux 系統間的檔案與指令兼容性低。
- Resolution: 使用 VSCode 的 Remote Development 模式讓開發、測試、調試都在 WSL 周遭完成。
- Example: 開啟 VScode 呼叫 WSL檔案並通過Remote Shell操作, 提供如本地系統般的開發體驗。

## Case 3: 利用 GPU 資源於 WSL
- Problem: 在 WSL 中無法有效使用 GPU，影響深度學習模型的性能。
- RootCause: GPU 驅動與 CUDA 的相依性問題，且缺乏設定支持。
- Resolution: 安裝 NVIDIA 的 Windows 驅動，配置CUDA 工具包於WSL。
- Example: 在 WSL 上執行 Docker 容器, 完整使用 GPU 的計算能力, 提高 AI 模型的推理速度。