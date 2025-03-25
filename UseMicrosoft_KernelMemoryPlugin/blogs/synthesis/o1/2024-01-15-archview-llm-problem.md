Case 1: API 呼叫與折扣計算不夠明確  
- Problem: 開發者在初始 Demo 中，未精確說明折扣邏輯，導致 LLM 可能誤讀或誤用 API，對於某些商品的折扣試算存在不一致。  
- RootCause: API 只提供商品單價、購物車金額試算等基礎端點，而未揭露折扣規則，LLM 只能靠多次嘗試推理，增加對話不確定性。  
- Resolution: 強化 API 設計，使折扣規則或定價機制更清晰，包括在 Swagger 或 Documentation 內明確列舉商品折扣條件。  
- Example: 當 18 天生啤酒具有第二件六折優惠時，API 可多增一個提示或在 response 的欄位顯示「有折扣」，使 GPTs 在呼叫 /api/carts/{cart-id}/estimate 時，更有效掌握折扣資訊。

Case 2: 認證流程造成 GPTs 呼叫困難  
- Problem: 作者在實作初期採用不夠標準化的登入驗證方式，GPTs 對於繁複的 Token exchange 或自定義流程難以正確操作，常出現錯誤呼叫。  
- RootCause: OAuth 等標準協定尚未全面引入，導致 AI 必須透過大量 Prompt 釐清細節，且仍易混淆登入、刷新 Token 的時機。  
- Resolution: 改用正式的 OAuth2 驗證介面與標準化登入畫面，讓 GPTs 只需理解「取得 Token → 呼叫 API」的統一流程。  
- Example: 作者調整系統至 v5.0.0 後，提供符合 OAuth 2.0 的登入並簡化 Token 機制，GPTs 能在邏輯上正確呼叫「/api/login」取得 Token，再呼叫其他 API。

Case 3: 前端 UX 與意圖表達衝突  
- Problem: 傳統 UX 偏好用詳細介面描述商品或操作，但 GPTs 以對話交互時，使用者可能只打模糊字眼如「幫我多加兩件啤酒」，容易造成商品識別不精準。  
- RootCause: 系統設計時未明確区分「需要使用者精準操作」與「可讓 AI 推理」的場景，導致介面和對話都夾雜資訊，增加混亂點。  
- Resolution: 釐清哪些操作能仰賴 GPTs 的推理，哪些操作需透過精準 API 或 UI 流程。可在 Swagger 文檔中為每個端點撰寫完整描述，提高 AI 理解度。  
- Example: 直接在 API 名稱或描述中標明「/api/products/{id}/addToCart — 用於將指定商品加入購物車」，方便 GPTs 使用時不再混淆商品代稱或 SKU。  

Case 4: LLM 覆蓋度與運算成本誤用  
- Problem: 某些場景僅屬基本計算或單純資料查詢，卻全部交給 GPTs 進行推理，造成運算成本攀高，且常出現無法保證 100% 正確性的問題。  
- RootCause: 未分辨好「適合自動算式」或「需語義推理」的界線；將所有需求都塞給 GPT 做整體回應，而忽略程式自行計算效能更佳。  
- Resolution: 針對明確、可用傳統演算法快速確定結果的需求，仍使用後端程式直接運算；僅將複雜或需要語言理解的部分交給 LLM。  
- Example: 作者在預算內選購商品的功能上，改為 API 先計算可行組合，再讓 GPTs 提供建議並做最終決策；而非直接令 LLM 逐步試誤去組合商品。

Case 5: Domain 與狀態機設計不足  
- Problem: LLM 因缺乏對 Domain 狀態切換的掌握，而誤觸不應該呼叫的端點或時序。例如在購物流程尚未產生訂單編號時嘗試調用結帳。  
- RootCause: 缺乏狀態機與嚴謹的 Domain 設計，API 沒有封裝好「允許哪些前置條件」和「可能的狀態流轉」。  
- Resolution: 引入有限狀態機（FSM）或 DDD Patterns，強化 API 對「在哪個狀態下能呼叫哪個端點」的把關，並於文件中提示。  
- Example: 若購物車尚無商品，就禁止調用「/api/checkout/create」；回傳 400 錯誤並明確說明「尚未達結帳流程」。GPTs 經過幾次呼叫就能學習到正確時機。

Case 6: 角色設定與 Prompt 擴充不足  
- Problem: 作者在掛上 Custom GPT 時，有時疏忽角色與目標任務的約束，讓 GPTs 的行為不夠聚焦，可能發散出不必要或誤導性回覆。  
- RootCause: 缺少在 GPTs 後台對店長角色、店內資訊使用規範的詳細說明；Prompt 也未藉實例或黑名單關鍵詞作防呆。  
- Resolution: 透過前期「角色設定完善」和「常用對話示例」，約束 GPTs 回應範圍；同時在 API 描述中加上更多可行提示與錯誤應對策略。  
- Example: 在 GPTs 歡迎詞後即聲明：「飾品與衣物類尚未上架，切勿向客人推廣此商品」，有助 AI 不再亂推薦非現有商品。

Case 7: 開發框架與維運流程欠缺標準  
- Problem: AI 驅動的應用仍然依賴作者自行摸索部署管線，對於程式更新、API 做版控以及 GPTs prompt 編輯，維運難度高。  
- RootCause: 缺乏明確開發框架（如 Semantic Kernel）或作業系統層級整合；往往「應用程式 + AI + DevOps」還在緣木求魚式的拼貼中。  
- Resolution: 建議導入 Semantic Kernel 或類似框架，以標準化方式管理 AI Plugins、Prompt、資料來源與版本控制，使應用可持續迭代。  
- Example: 若將安德魯小舖 API 與 GPTs 設定整合進 Semantic Kernel，能清楚分工「Plugins 端點」、「Memory 記錄」、「Planner 配置」，方便團隊協同並規模化。