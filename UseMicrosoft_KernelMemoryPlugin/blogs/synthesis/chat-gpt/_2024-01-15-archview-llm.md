scss
Copy
Edit

1. 多層次摘要 (Multi-level Summaries)
1.1 高階摘要 (High-level Summary)
本篇文章以「安德魯小舖 GPTs」的實驗專案為引子，說明大型語言模型 (LLM) 與 API、應用程式及作業系統整合後，將如何顛覆傳統軟體開發模式。作者透過 PoC 實作，強調未來「意圖」與「計算」的分界、AI Friendly 的 API 設計、以及 Copilot/LLM 成為新一代應用程式核心。文中同時探討架構師與開發人員的角色如何演進，並預測 Microsoft 及業界在 AI 時代的技術佈局趨勢。 (來源: 2024-01-15-archview-llm.md, 段落#1)

1.2 中階摘要 (Mid-level Summary)
- 第一部分：安德魯小舖 GPTs - Demo  
  作者以「安德魯小舖 GPTs」PoC 展示如何把 GPTs (基於 ChatGPT) 與自製 API 整合。此 PoC 讓 AI 扮演「店員」角色，實際對話過程中能瀏覽商品、計算折扣、結帳、查詢訂單紀錄等。此示例凸顯了 AI 取代傳統 Chatbot 的顯著能力。(來源: 2024-01-15-archview-llm.md, 段落#2~#7)

- 第二部分：軟體開發的改變  
  文章主張：傳統使用者介面 (UI) 是「下指令」思維；而 AI/LLM 則能理解人類「意圖」，帶來革命性的 UX 改變。未來軟體會以 LLM 為中樞，API 為關鍵介面，UI 不再是絕對核心，並將「AI Ready」列為新一代軟體的關鍵。(來源: 2024-01-15-archview-llm.md, 段落#8~#10)

- 第三部分：看懂 Microsoft 的 AI 技術布局  
  作者聚焦於 Microsoft 與 OpenAI 的合作，闡述 Azure Open AI Service、Copilot 與 Semantic Kernel 三者如何形塑未來的「AI 生態系」：  
  1) Azure Open AI Service 供應 GPT 模型與雲端資源；  
  2) Copilot 預計成為 OS 乃至所有應用的主入口；  
  3) Semantic Kernel 提供 AI 應用開發的核心框架。(來源: 2024-01-15-archview-llm.md, 段落#11~#13)

- 第四部分：架構師、資深人員該怎麼看待 AI  
  文章建議資深人員與架構師導入「AI Friendly」的系統設計：分辨哪些需求可交由 LLM 處理、哪些屬於傳統計算/交易必須保持精確，並著重於將 API 設計得更清楚、合乎領域邏輯，以利 LLM 正確呼叫。(來源: 2024-01-15-archview-llm.md, 段落#14~#16)

- 第五部分：開發人員該怎麼看待 AI  
  作者提醒開發人員可先熟悉 AI 工具 (如 GitHub Copilot) 提升產能，也要掌握新一代框架 (如 Semantic Kernel)、RAG/向量資料庫等技術，並強化領域知識及 API 設計能力。(來源: 2024-01-15-archview-llm.md, 段落#17~#18)

- 第六部分：結論  
  未來軟體開發將逐漸以 LLM 為核心，Copilot 為操作介面，API 成為關鍵連結點。作者認為現在正是「大改變」前夜，並呼籲從業者提升基礎實力並擁抱新工具。(來源: 2024-01-15-archview-llm.md, 段落#19)

1.3 細節化摘要 (Low-level Summaries)

以下將全文依主要論述拆為十個段落，並為每段提供摘要、關鍵標籤與來源標記。

1) [段落摘要] 回顧 2016 年作者曾發文探討 Microsoft 與開源策略；對比 2023 年 AI 的爆發，作者感到軟體產業正面臨另一波大變革。  
   [關鍵標籤] #OpenSource #Microsoft #AI趨勢  
   (來源: 2024-01-15-archview-llm.md, 段落#1)

2) [段落摘要] 介紹安德魯小舖 GPTs PoC：基於 OpenAI GPTs，實現能對話、查詢與結帳的線上商店 API。重點是 GPTs 可理解使用者需求後自動調用 API。  
   [關鍵標籤] #PoC #GPTs #API整合  
   (來源: 2024-01-15-archview-llm.md, 段落#2)

3) [段落摘要] 作者實際演示如何與 GPTs 互動，包括查看商品、加入購物車、計算折扣、結帳等。展現 GPTs 自動呼叫多個 API 以滿足複雜指令的能力。  
   [關鍵標籤] #Demo #折扣計算 #AI自動化  
   (來源: 2024-01-15-archview-llm.md, 段落#3)

4) [段落摘要] 作者持續刁難 GPTs，讓其理解模糊語意（如不要酒類）並自動修改訂單內容，並根據對話紀錄提供過往購買紀錄與統計，強調 GPTs 的推論與語意萃取潛能。  
   [關鍵標籤] #對話理解 #語意分析 #推理能力  
   (來源: 2024-01-15-archview-llm.md, 段落#4)

5) [段落摘要] 作者提及 PoC 小結：AI 已不僅是回覆文字，而能扮演「領域專家」對接系統；且若 API 設計不夠精準，Prompt 就得更複雜才能教 AI 正確操作。  
   [關鍵標籤] #API設計 #PromptEngineering #領域專家  
   (來源: 2024-01-15-archview-llm.md, 段落#5)

6) [段落摘要] 作者探討「軟體開發的改變」：傳統 UX 在於簡化操作，AI 則能理解意圖；LLM 與 API 結合將改造整個系統架構，帶來 UX 大幅變革。  
   [關鍵標籤] #UX #LLM #系統架構  
   (來源: 2024-01-15-archview-llm.md, 段落#6)

7) [段落摘要] 作者預測未來所有應用都會以 AI 為中心：LLM 在系統中扮演中控角色；API 的一致性與合理性更為重要，因為呼叫方不再是 Developer，而是 AI。  
   [關鍵標籤] #AI中心化 #中控 #未來預測  
   (來源: 2024-01-15-archview-llm.md, 段落#7)

8) [段落摘要] Microsoft AI 技術布局：Azure Open AI Service、Copilot、Semantic Kernel 的三者整合。OpenAI 模型供應算力，Copilot 作為 OS 級介面，Semantic Kernel 作為開發框架。  
   [關鍵標籤] #Microsoft #AzureOpenAI #Copilot #SemanticKernel  
   (來源: 2024-01-15-archview-llm.md, 段落#8)

9) [段落摘要] 作者從應用程式框架出發，以 Semantic Kernel 與 LangChain 為例，分析未來軟體開發將以 LLM Orchestration 為核心，UI、API、資料庫都圍繞其中。  
   [關鍵標籤] #應用程式框架 #LLMOrchestration #LangChain  
   (來源: 2024-01-15-archview-llm.md, 段落#9)

10) [段落摘要] 文章最後談到架構師與開發人員該如何面對：①分清意圖與計算；②API 設計精準合理；③UI 以 Task 為單位拆解；④挑選正確開發框架；⑤深化領域知識。  
    [關鍵標籤] #架構師策略 #開發者技能 #未來展望  
    (來源: 2024-01-15-archview-llm.md, 段落#10)


2. Q&A 視角 (Question & Answer)

以下整理 7 組讀者常見或可能的提問，並給予回答與來源標記：

Q1: 「為什麼作者認為傳統 Chatbot 與 GPTs 有如此大的差距？」
A1: 傳統 Chatbot 多以有限對話流程實作，無法有效處理複雜、模糊的語意；GPTs 則透過大型語言模型精準理解並轉化需求，因此呈現「類人」推理能力。(來源: 2024-01-15-archview-llm.md, 段落#2, #4)

Q2: 「在開發『安德魯小舖 GPTs』時，最困難的地方是什麼？」
A2: 主要是確保 API 與 LLM 的互動順暢：API 設計不當會增加大量 Prompt 成本，並且必須解決登入、授權等傳統流程的複雜度。(來源: 2024-01-15-archview-llm.md, 段落#2, #5)

Q3: 「文章提到的預算與折扣計算，為何建議用程式運算而非 LLM？」
A3: 因為 LLM 推理雖然靈活，但出錯機率與成本較高；而計算交易金額屬精準度高的場景，故建議以程式/演算法負責。(來源: 2024-01-15-archview-llm.md, 段落#6)

Q4: 「LLM 真的能聽懂使用者在對話中隱含的需求嗎？」
A4: 作者多次示範自然語言下單或隱含條件（如避免酒類），GPTs 能自動調整 API 呼叫，顯示出 LLM 對意圖的理解能力。(來源: 2024-01-15-archview-llm.md, 段落#3~#4)

Q5: 「為什麼要特別強調『AI Friendly』的 API 設計？」
A5: 因為未來呼叫 API 的不再是開發者，而是 LLM。若 API 不易理解或缺乏狀態機控管，AI 會難以正確呼叫，造成結果錯誤或操作失敗。(來源: 2024-01-15-archview-llm.md, 段落#7, #14)

Q6: 「Microsoft 布局 AI 有哪些關鍵技術？」
A6: 文章指出三大面：Azure OpenAI Service 提供 GPT 模型算力、Copilot 作為 OS 與應用的使用介面、Semantic Kernel 則是 AI 時代的核心開發框架。(來源: 2024-01-15-archview-llm.md, 段落#8)

Q7: 「開發者可從哪些面向準備自身技能？」
A7: (1) 善用 AI 工具提升效率；(2) 熟悉向量資料庫、RAG 等技術；(3) 精進 API/DDD 設計能力；(4) 掌握 Semantic Kernel 或類似框架。(來源: 2024-01-15-archview-llm.md, 段落#17~#18)


3. Problem–RootCause–Resolution–Example 視角

以下列舉三個文章中隱含的重要問題/挑戰，並以「PRRE」格式呈現：

(1)
- Problem: 使用者需求往往含有模糊語意或臨時性決策，例如「預算內」「不要酒類」等複雜場景。  
- Root Cause: 傳統軟體流程無法動態理解「語意」；只能被動依指令執行固定流程。(來源: 2024-01-15-archview-llm.md, 段落#3~#4)  
- Resolution: 導入 LLM 掌管對話上下文與意圖解析，利用 API 進行精確操作、查詢與交易。  
- Example: 「安德魯小舖 GPTs」對話示範，AI 會自動扣除酒類商品、更新購物車內容並完成結帳。(來源: 2024-01-15-archview-llm.md, 段落#4)

(2)
- Problem: 過去多數 API 只需面向開發者，本身易於「能跑就好」，設計不夠嚴謹。當 LLM 需要透過這些 API 服務時，若邏輯錯綜複雜會導致錯誤。  
- Root Cause: 不完善的 API 規格或狀態機，以及缺乏領域抽象，讓 AI 難以理解。(來源: 2024-01-15-archview-llm.md, 段落#5, #14)  
- Resolution: 精確的「AI Friendly」API 設計：以領域邏輯為基礎，減少特例，強調狀態封裝與清晰參數。  
- Example: 範例中針對折扣計算、登入流程等，修正 API 並簡化以符合標準 OAuth2，才讓 GPTs 更好地呼叫。(來源: 2024-01-15-archview-llm.md, 段落#5)

(3)
- Problem: 未來 AI/LLM 與 UX 深度結合，UI 設計與使用者意圖存在落差，傳統「點擊介面、流程導向」將無法完整呈現高度彈性的需求。  
- Root Cause: 使用者操作行為無法完全預測，且需求瞬息萬變；單靠 UI/流程定義難以涵蓋所有狀況。(來源: 2024-01-15-archview-llm.md, 段落#6, #7)  
- Resolution: 改以 AI (LLM) 為核心，UI 僅輔助必要的精準操作；大量「意圖」交由 LLM 解析後，再透過 API 完成。  
- Example: 作者 PoC 中，多次以自然語言直接下購物要求，AI 透過對話語境決定後續動作。(來源: 2024-01-15-archview-llm.md, 段落#3)


4. PARA 視角 (Project, Area, Resource, Archive)

- Project (與具體專案/目標有關)
  - 「安德魯小舖 GPTs」PoC 專案：目標是測試 GPTs 與線上商店 API 的整合度，讓 AI 真正扮演店員與顧問角色。(來源: 2024-01-15-archview-llm.md, 段落#2)
  - Microsoft Copilot/AI OS 化：作者預測未來 Microsoft 可能將 AI 深度融入 Windows OS，使 Copilot 成為主入口。(來源: 2024-01-15-archview-llm.md, 段落#8)

- Area (長期關注領域)
  - AI Friendly 的軟體架構：包括 LLM Orchestration、API First、Semantic Kernel 等技術與框架。(來源: 2024-01-15-archview-llm.md, 段落#7, #9)
  - 維繫 AI 與 UX 的平衡：如何在精準計算與模糊語意之間找到最佳做法。(來源: 2024-01-15-archview-llm.md, 段落#6)

- Resource (工具、方法、技術參考)
  - GitHub Copilot、OpenAI GPTs：用於協助撰寫程式碼、自然語言對話與 API 呼叫。(來源: 2024-01-15-archview-llm.md, 段落#2, #5)
  - Semantic Kernel、LangChain：AI 應用開發框架，可整合 LLM、Plugins、Memory、Planner 等機制。(來源: 2024-01-15-archview-llm.md, 段落#9)

- Archive (歷史記錄、存檔、補充資訊)
  - 作者回顧 2016 年寫過 .NET 與開源策略文章；對比 2023 年，軟體生態因 AI 再次翻轉。(來源: 2024-01-15-archview-llm.md, 段落#1)
  - 2023 年下半年 .NET Conf 相關演講分享與討論，強調 AI + API 大勢所趨。(來源: 2024-01-15-archview-llm.md, 段落#19)

