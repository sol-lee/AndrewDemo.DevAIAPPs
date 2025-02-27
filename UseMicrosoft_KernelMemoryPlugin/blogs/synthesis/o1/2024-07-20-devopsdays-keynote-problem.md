Case 1: AI 嵌入時，API 設計鬆散  
- Problem: AI 呼叫到不完善的 API，導致資料操作錯誤或無法正確回應使用者需求。  
- RootCause: 缺乏狀態機規範、授權機制不清晰，或 API 過度鎖死於特定 UI 邏輯，難以適應多樣 AI 呼叫模式。  
- Resolution: 採行 APIFirst 思維，強化狀態機規劃與確保必要操作都能經由原子化的 API 完成，並設計好 Scope 與授權流程。  
- Example: 安德魯小舖在最初測試需反覆添加文件與提示，才能讓 GPTs 正確處理商品訂單和結帳，隨後優化訂單 API 改用狀態機思維，大幅減少錯誤呼叫。  

Case 2: 終端體驗不佳，使用者不曉得 AI 能做些什麼  
- Problem: 傳統介面與對話式交互彼此分離，造成使用者摸不著頭緒，無法發揮 AI 幫手優勢。  
- RootCause: 開發團隊未規劃 AI 如何與前端 UI 整合，或忽略自然語言跟傳統操作流程的互補性。  
- Resolution: 採 Copilot 模式，讓使用者可選擇指令操作或直接提問，並在感知到用戶「卡關」時由 AI 主動提供提示或建議。  
- Example: 安德魯小舖 Copilot 版示範：平時仍使用簡單選單作業，僅在預算分配或情境補充時，使用者可呼叫 Copilot 處理計算或推薦，減少操作阻力。  

Case 3: 難以掌握使用者隱藏需求、情緒或個人化服務  
- Problem: 傳統零售或電商靠大數據推定需求，不易即時捕捉個人狀態，缺乏深層互動與彈性。  
- RootCause: 現有 UX 侷限於粗略統計與介面引導，無法及時反映消費者口語化之情緒或喜好。  
- Resolution: 採用 LLM 解析對話，動態判斷購買行為與情緒分數，並存入客戶標籤或訂單註記。未來可配合再訓練或企業知識庫，更完整貼近使用者需求。  
- Example: 安德魯小舖透過 GPTs 預先紀錄會員喜好，並在對話中即時調整，於結帳時也自動抓取滿意度線索。讓店長 GPTs 得以做更個人化的商品推薦。  

Case 4: RAG 驅動的知識庫難以維持實時與準確度  
- Problem: AI 要回答產品或技術細節，需拉取公司內部龐大文檔，但若只靠 LLM 訓練又不夠即時或費用昂貴。  
- RootCause: 大模型訓練成本高昂且更新頻率低，如僅依原始訓練，回答品質易過時；部分文字超出模型已知範圍。  
- Resolution: 建立 RAG （檢索增強生成）流程：先以 Embedding 索引最新內容，AI 須回答前先檢索最相關文本，再綜合答案，減少不必要的模型再訓練。  
- Example: 「安德魯的部落格 GPTs」將所有文章透過向量資料庫管理，供 ChatGPT 檢索並編進 prompt，能回答多數最近更新的文章細節。  

Case 5: 架構與部署周期無法涵蓋 AI 服務或模型更新  
- Problem: 傳統 CI/CD 只處理程式與組態檔，缺乏對 AI 模型或推論服務的版本化與佈署步驟，造成 DevOps 中斷。  
- RootCause: AI 須考量 GPU 或向量資料庫環境、模型更新策略與 Token 成本控管，若無 Pipeline 管理恐使整個產品部署失控。  
- Resolution: 在既有三大 Pipeline（Application/Configuration/Environment）之外，再補上 AI Pipeline（模型建置、測試與版本管理），整合到 GitOps／DevOps 流程中。  
- Example: 作者在 Demo 中自行建構 SemanticKernel 或 GPTs Engine；若規模變大，需為 AI 服務另設獨立資源及自動化部署程序，確保在雲端或自建 GPU 上更新模型不致混亂。