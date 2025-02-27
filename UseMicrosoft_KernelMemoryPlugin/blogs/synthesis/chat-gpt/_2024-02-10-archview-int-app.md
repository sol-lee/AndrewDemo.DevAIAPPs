scss
Copy
Edit

1. 多層次摘要 (Multi-level Summaries)

1.1 高階摘要 (High-level Summary)
本篇主要探討如何在傳統應用程式中，逐步導入大型語言模型 (LLM) 以提供對話式智慧功能。作者以「安德魯小舖」購物系統為範例，說明從最基本的程式指令操作，到使用 LLM 輔助風險評估、即時建議，以及最終允許 LLM 透過自然語言呼叫外部 API 自動完成任務的演進過程。文中亦對未來軟體開發、系統架構與開發者角色的轉變提出觀察，強調掌握 Prompt Engineering 與整合 LLM Plugins/Skills 的重要性。
(來源: 2024-02-10-archview-int-app.md, #3, #9, #43)

1.2 中階摘要 (Mid-level Summary)

● 「安德魯小舖」的演進
- 從無智慧的選單式操作，到在關鍵時刻用 LLM 做風險評估，再到全程操作提示 (Copilot 模式)，最後發展為全對話式自動執行。此過程展現了如何將 LLM 的理解與推理能力融入傳統應用程式中。
(來源: 2024-02-10-archview-int-app.md, #9~#10, #20, #21, #26)

● LLM 應用的系統架構
- 以 Semantic Kernel (SK) 為例，強調 LLM（大腦）+ Chat History（短期記憶）+ Knowledge / RAG（長期知識）+ Plugins/Skills（API 或外部功能）+ Persona（角色設定）五大要素的組合。只有將上述要素完整整合，才能使應用程式有效運用 LLM 完成複雜任務。
(來源: 2024-02-10-archview-int-app.md, #34, #46, #67)

● 開發流程與提示工程 (Prompt Engineering)
- 在 Copilot 模型中，開發者需要撰寫恰當的 System Prompt 及 User Prompt，告知 LLM 其角色定位、規則與操作情境，並在關鍵功能上進行評估、提示或自動化行動。Prompt 的品質直接影響到 LLM 能否正確運行。
(來源: 2024-02-10-archview-int-app.md, #15~#20, #60, #61)

● 未來展望
- 隨著 LLM 能力不斷提升，執行任務的速度與成本也將逐漸優化。作者預估未來開發者將更著重於定義業務與流程邏輯、撰寫 Prompt 與 Plugins/Skills，而不再只是在程式碼層面執行細部實作。
(來源: 2024-02-10-archview-int-app.md, #78, #79, #90, #92)

1.3 細節化摘要 (Low-level Summaries)

以下以主要段落為單位，列出核心重點、關鍵標籤與來源標記。

段落 #1～#2  
摘要：標題與文章封面圖，說明本篇主題是關於 LLM 在應用程式開發的實踐。  
關鍵標籤：LLM、AI、應用程式開發、封面圖  
(來源: 2024-02-10-archview-int-app.md, #1~#2)

段落 #3～#5  
摘要：回顧上一篇文章如何嘗試透過 GPTs 整合購物流程，產生了超過原本預期的效果，引出「未來應用程式如何運用 AI？」與「未來開發流程與角色」的兩大問題。  
關鍵標籤：GPTs、整合購物、未來應用程式、未來開發  
(來源: 2024-02-10-archview-int-app.md, #3~#5)

段落 #6～#8  
摘要：文章將分兩階段探討——一方面利用 Azure OpenAI + Semantic Kernel 建置 PoC；另一方面深入聊 LLM 對軟體設計架構的重大變革。作者強調自己是 AI 門外漢，分享摸索經驗。  
關鍵標籤：PoC、Semantic Kernel、軟體架構  
(來源: 2024-02-10-archview-int-app.md, #6~#8)

段落 #9～#13  
摘要：介紹「安德魯小舖」的核心概念，包含從典型購物系統到漸進式導入 LLM 的四個階段。第一階段是單純選單式的標準操作模式，作為對照組。  
關鍵標籤：安德魯小舖、漸進式導入、對照組  
(來源: 2024-02-10-archview-int-app.md, #9~#13)

段落 #14～#20  
摘要：在結帳前用 AI 幫忙評估風險，提醒客戶例如「酒精飲料之法律限制」等。重點在於如何在關鍵環節透過 Prompt 與背後的 FAQ/規則設定，讓 LLM 產生貼近人類常識的建議。  
關鍵標籤：AI 風險評估、Prompt、常識推理  
(來源: 2024-02-10-archview-int-app.md, #14~#20)

段落 #21～#25  
摘要：展示「操作過程中全程輔助」的概念，類似 GitHub Copilot。系統在每一步的操作後，都會將操作情境以自然語言餵給 LLM，判斷是否需要提示。此處再次顯示 Prompt 撰寫與資訊傳遞的重要性。  
關鍵標籤：Copilot、操作歷程、即時建議  
(來源: 2024-02-10-archview-int-app.md, #21~#25)

段落 #26～#33  
摘要：最終讓 AI 代替使用者操作，透過自然語言指示 AI 呼叫不同外部函式 (API)。舉例「1000 元預算買酒、可樂與綠茶」，系統自動試算並更新購物車，然後再回給使用者檢查。  
關鍵標籤：對話式操作、API 呼叫、Function Calling  
(來源: 2024-02-10-archview-int-app.md, #26~#33)

段落 #34～#43  
摘要：進一步探討 LLM 系統架構的四個發展層次（Chatbot、RAG、Copilot、Fully autonomous），並連結到 Microsoft Semantic Kernel 的官方圖示。  
關鍵標籤：LLM 架構、Semantic Kernel、Chatbot、RAG、Copilot  
(來源: 2024-02-10-archview-int-app.md, #34~#43)

段落 #44～#50  
摘要：作者解釋 PoC 的選擇與思路，強調在架構階段先搞清楚何時「該」用 LLM，才能落實智慧化的功能。也強調 Prompt Engineering 與 Skills/Plugins 的重要性。  
關鍵標籤：PoC、智慧化、Prompt Engineering、技能設計  
(來源: 2024-02-10-archview-int-app.md, #44~#50)

段落 #51～#59  
摘要：細分 LLM 搭配 Chat History（短期記憶）與 RAG（長期知識庫）的運作模式，並以人類的「聯想」對應向量資料庫的概念，展示了如何在巨大文本中進行有效檢索。  
關鍵標籤：Chat History、短期記憶、RAG、向量資料庫、聯想  
(來源: 2024-02-10-archview-int-app.md, #51~#59)

段落 #60～#63  
摘要：進一步談到 Skills/Plugins，說明 LLM 透過 Function Calling 呼叫外部技能 API，才能真正「做事」。作者以 ChatGPT Plugins 與 Semantic Kernel Skills 為例，闡述該設計理念。  
關鍵標籤：Skills、Plugins、Function Calling、Semantic Kernel  
(來源: 2024-02-10-archview-int-app.md, #60~#63)

段落 #64～#66  
摘要：Persona(人格)設定的重要性，包含 System Prompt 與使用者的個人化資訊，能決定 LLM 回應的口吻、行為與範圍。  
關鍵標籤：Persona、System Prompt、個人化  
(來源: 2024-02-10-archview-int-app.md, #64~#66)

段落 #67～#77  
摘要：總結完整的 SK 架構：LLM、短期記憶(對話上下文)、長期知識(RAG)、Plugins/Skills，以及 Persona 組合成一個可執行複雜任務的智慧代理人。亦舉例 C# 中如何將方法註冊為 Plugin，及其運作原理。  
關鍵標籤：SK 架構、智慧代理、Plugins 設計、C#  
(來源: 2024-02-10-archview-int-app.md, #67~#77)

段落 #78～#93  
摘要：作者對未來軟體開發的展望——從「複製貼上程式碼」進階到「AI 自動生成並執行」，再到「用自然語言直接撰寫程式」。引用「The End of Programming」論點，說明若能容忍 AI 與人一樣的「不確定性」，就能釋放 AI 的潛力與效率。  
關鍵標籤：未來發展、End of Programming、AI 自動化、程式語言演進  
(來源: 2024-02-10-archview-int-app.md, #78~#93)

--------------------------------------------------------------------------------

2. Q&A 視角 (Question & Answer)

以下列出 8 組可能的讀者常見問題，每則答案後附上對應來源標記。

Q1: 「安德魯小舖」系統要如何逐步導入 LLM？  
A1: 文章中將整合 LLM 的過程分成四個階段：先從傳統操作介面作為對照組，再於結帳等關鍵功能導入風險評估提示，接著提供全程 Copilot 式建議，最終讓 LLM 完全透過對話自動呼叫後端功能完成購物流程。  
(來源: 2024-02-10-archview-int-app.md, #9~#13, #26)

Q2: 為什麼要在結帳流程中使用 LLM 進行風險評估？  
A2: 因為 LLM 能根據上下文與常識，對商品（如含酒精或含糖飲料）或客戶需求（未成年？健康問題？）給出合理提醒，提供比傳統規則檢查更貼近人性的建議。  
(來源: 2024-02-10-archview-int-app.md, #14~#15)

Q3: 什麼是「Copilot 式」的操作輔助？  
A3: 類似 GitHub Copilot 的概念，系統在使用者每次操作後，將操作內容以自然語言形式傳給 LLM；若 LLM 判定需要提醒或建議，就即時顯示給使用者。它透過連續提示工程讓 AI 有「全程陪伴式」的智慧輔助。  
(來源: 2024-02-10-archview-int-app.md, #21~#23)

Q4: 「Fully autonomous」對話式操作如何實現？  
A4: 需先將所有可呼叫的後端功能定義成可讓 LLM 理解的 Plugins/Skills，並提供其參數結構與用途描述。LLM 解析自然語言指令，決定調用哪個 Plugin，並組合執行，最後將結果以自然語言回饋給使用者。  
(來源: 2024-02-10-archview-int-app.md, #26~#33, #60~#63)

Q5: Semantic Kernel 的核心概念是什麼？  
A5: 它透過抽象化的方式，把 LLM、記憶模組 (Memory)、Plugins (Skills) 與 Persona 等要素整合起來，讓開發者能方便地建置具備「閱讀上下文、檢索知識、執行外部 API、個人化回應」等功能的智慧代理。  
(來源: 2024-02-10-archview-int-app.md, #34, #46, #74)

Q6: 為何要使用 RAG（Retrieval Augmented Generation）？  
A6: LLM 預設只有「通用」知識。若需引用組織內部或領域專業資料，就得先將該資料嵌入向量資料庫，並於使用者發問時檢索並附加到 Prompt，使 LLM 在回答時能參考最新且專屬的內容。  
(來源: 2024-02-10-archview-int-app.md, #37~#38, #57~#59)

Q7: Prompt Engineering 對開發者有何影響？  
A7: 開發者不再只寫程式碼，還要撰寫並優化 Prompt，以決定 LLM 理解和回應方式。Prompt 的品質直接影響系統最終表現，使得語言與工程的結合變得更加重要。  
(來源: 2024-02-10-archview-int-app.md, #15~#20, #44~#50, #78)

Q8: 文章提到未來「用自然語言寫程式」的可能性，這現實嗎？  
A8: 作者認為要達到大規模商業應用，仍需解決 LLM 的運算成本與不確定性問題，但這趨勢不可逆。就像過去從組合語言走到高階語言，最終也有機會進到「全自然語言程式」的階段。  
(來源: 2024-02-10-archview-int-app.md, #79~#86, #90~#93)

--------------------------------------------------------------------------------

3. Problem–RootCause–Resolution–Example 視角

以下列出文中提及的幾個實作/應用問題 (Problem)、背後原因 (Root Cause)、解法 (Resolution) 與示例 (Example)；並附上來源標記。

Problem 1  
- Problem: 在應用程式內導入 LLM 後，難以確定 AI 會不會「誤判」而做出錯誤功能呼叫。  
- Root Cause: LLM 是基於機率預測，存在不可預測與幻覺問題，且 Plugins/Skills 若過多或描述不精確，AI 可能誤用或忘記呼叫。  
- Resolution: 精心設計 Prompt（系統提示與描述）與 Plugins（API）說明，並針對真實應用場景限制可呼叫的功能範圍，測試與微調。  
- Example: 「安德魯小舖」用結帳限制的 System Prompt，針對買酒、買含糖飲料等提供明確法規與健康提示，降低出錯機率。  
(來源: 2024-02-10-archview-int-app.md, #14~#16, #60~#63)

Problem 2  
- Problem: AI 在結帳流程給出的提醒不夠一致，第一次沒提醒買酒年齡限制、第二次才提醒。  
- Root Cause: LLM 回應具有隨機性，且 Prompt 中的 FAQ 規則未必每次都被完整「注意到」。  
- Resolution: 在 Prompt 加強 Context 與可重複查詢 RAG 資料；或可加入更嚴謹的檢查流程，從外部函式做「最終驗證」。  
- Example: 結帳前統一將「購物車內所有酒精性飲料與使用者年齡」交由 Rule-based 程式檢查，再由 LLM 做自然語言的最終提示。  
(來源: 2024-02-10-archview-int-app.md, #20, #24~#25)

Problem 3  
- Problem: 需要大規模知識，但 Prompt Token 成本過高、速度又慢。  
- Root Cause: LLM 只能依賴 Prompt 提供的上下文；若直接大量拼接完整文字到 Prompt，會造成 Token 費用與反應時間的飆升。  
- Resolution: 導入 RAG 及向量資料庫，先用 Embedding 進行檢索只取最相關片段，再餵給 LLM。  
- Example: 替「安德魯小舖」加上公司內部 FAQ 與活動資訊，先透過 Embedding 檢索到合適段落，才送入 Prompt，減少不必要負擔。  
(來源: 2024-02-10-archview-int-app.md, #37~#38, #57~#59)

Problem 4  
- Problem: 現行程式開發習慣與流程無法迅速切換到「Prompt Engineering」模式。  
- Root Cause: 過去軟體開發多採嚴謹可控的程式結構，缺乏對「自然語言不確定性」的思維與工具支援。  
- Resolution: 引入像 Semantic Kernel、LangChain 等框架，把程式與 LLM 結合並建立共通開發介面，同時培養 Prompt 編寫的經驗。  
- Example: 開發者在 .NET 環境下可使用 Semantic Kernel 註冊 Plugins，並練習如何優化 Prompt，逐步適應新的開發型態。  
(來源: 2024-02-10-archview-int-app.md, #44~#50, #60~#63, #67)

--------------------------------------------------------------------------------

4. PARA 視角 (Project, Area, Resource, Archive)

以下嘗試將文中資訊歸納至 PARA 模型：

Project (與具體專案/目標有關的段落)
- 「安德魯小舖」四階段演進之 PoC 專案 (來源: 2024-02-10-archview-int-app.md, #9~#10, #26)
- 以 Azure OpenAI + Semantic Kernel 重寫購物流程 (來源: 2024-02-10-archview-int-app.md, #34, #44)
- 「安德魯小舖 GPTs」整合購物網站 API (來源: 2024-02-10-archview-int-app.md, #3~#4, #32)

Area (長期關注領域)
- LLM 與 Copilot 模式在軟體開發中的應用 (來源: 2024-02-10-archview-int-app.md, #21~#23, #41)
- Prompt Engineering 與 Plugins/Skills 設計方法 (來源: 2024-02-10-archview-int-app.md, #15~#16, #60~#63)
- 架構師觀點：從無狀態 Chatbot 到 Fully autonomous Agent 的進程 (來源: 2024-02-10-archview-int-app.md, #34~#43)

Resource (工具、方法、技術參考)
- Microsoft Semantic Kernel 與其功能架構 (來源: 2024-02-10-archview-int-app.md, #46, #74)
- Azure OpenAI GPT-4 模型與 Function Calling 機制 (來源: 2024-02-10-archview-int-app.md, #34, #62)
- RAG (Retrieval Augmented Generation) 與向量資料庫 (來源: 2024-02-10-archview-int-app.md, #37~#38, #57~#59)
- ChatGPT Plugins 與 GPTs Custom Actions (來源: 2024-02-10-archview-int-app.md, #62~#63)

Archive (歷史記錄、存檔、補充資訊)
- 「安德魯小舖」早期 POC 的結構與成果比較 (來源: 2024-02-10-archview-int-app.md, #3~#5, #34)
- 文章末段對未來十年軟體工程演化趨勢的看法 (來源: 2024-02-10-archview-int-app.md, #78~#93)
- 引用外部影片與文章連結，記錄作者研究與靈感來源 (來源: 2024-02-10-archview-int-app.md, #36, #88~#91)
