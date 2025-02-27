1. 多層次摘要 (Multi-level Summaries)

1.1 高階摘要 (High-level Summary)
本篇文章回顧作者在 DevOpsDays Taipei 2024 擔任 Keynote 演講的主要內容，從先前倡導的「API First」概念延伸到「AI First」的應用，透過多個範例（DEMO）展示如何將大型語言模型 (LLM) 與既有的軟體系統整合，強調未來軟體服務若要善用 AI，必須從基礎的 API 設計品質與基礎建設著手。作者也指出，面對「AI＋軟體開發」的新時代，開發人員需要具備 API First、Prompt Engineering、RAG、部署管線等多方面的新基礎技能，才能打造出以 AI 驅動的應用程式。 (來源: 2024-07-20-devopsdays-keynote.md, 整體)

1.2 中階摘要 (Mid-level Summary)

(1) 前言與主旨  
作者由近年在 DevOpsDays 的演講脈絡切入，說明從「API First」到「AI First」的轉變背景，並回顧自己在 LLM 應用、RAG 與相關研究的成長過程。核心結論在於：當 AI 成為軟體系統的關鍵元件時，開發團隊要先準備好 API 設計與基礎建設，才能真正落實 AI First。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#1)

(2) DEMO：AI 如何重新定義使用者體驗  
作者展示了「安德魯小舖 GPTs」的情境，包括以對話方式完成購物、個人化推薦、即時偵測與紀錄顧客滿意度等，用「降維打擊」來形容 LLM 對傳統 UX/介面設計的衝擊。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#2~#5)

(3) AI 與軟體開發的結合  
作者探討在應用程式中導入 AI 的結構改變，從過去 MVC 架構延伸出「Copilot」模式，讓 LLM 與控制器並存。重點在於：  
- API 設計品質 (AI DX)  
- Prompt Engineering (如何讓 LLM 理解並執行工作)  
- RAG (檢索增強生成) 與基礎建設 (算力、資料更新、部署管線)  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#6~#10)

(4) 零售業的 AI 應用案例  
作者引用老闆 Happy 在另一場演講中的零售業案例，說明「AI 代理人 (Agent)＋引擎 (Engine)」的協同模式，實際落地到「消費心理」「業務員的敏銳度」等，凸顯 AI 對零售業銷售場景產生的深層影響。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#11)

(5) 結語與未來展望  
文章最後總結：  
- 「API First」與「AI First」融合是大勢所趨  
- 開發人員要先掌握基礎的架構設計、API 設計、AI 工程技巧 (Prompt、RAG、部署等)  
- AI 會逐漸滲透到所有業務與技術領域，現階段正是研究與 PoC 的好時機  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#12~#14)

1.3 細節化摘要 (Low-level Summaries)

以下根據本文主要段落順序，進行較細緻的摘要，並附上關鍵標籤與來源標記。

段落 #1【開場與背景】  
摘要：作者在 DevOpsDays Taipei 2024 的 Keynote 講題，延續前幾年談論的「API First」，進一步闡述如何轉向「AI First」。主旨是透過數個 AI + API 結合的實作範例，來說明未來軟體開發與 AI 的深度整合。  
關鍵標籤：DevOpsDays、API First、AI First、Keynote  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#1)

段落 #2【從「API First」到「AI First」的動機】  
摘要：介紹近兩年 AI 技術 (尤其是 LLM) 快速成長，作者認為 AI 不應只是一個「工具」，而是能作為軟體的核心元件。為因應這點，需要強調高品質的 API 設計，因為 AI 代理人會直接呼叫這些 API。  
關鍵標籤：大模型、LLM、API 品質、代理人 (Agent)  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#2)

段落 #3【DEMO #1：安德魯小舖 GPTs - 對話式購物】  
摘要：示範透過聊天介面，即可達成推薦商品、加入購物車、結帳、顯示訂單等流程，凸顯 LLM 可主動理解使用者意圖、並透過 API 執行操作。作者強調這種「意圖理解＋呼叫 API」的能力，將改寫傳統 UX。  
關鍵標籤：對話式介面、使用者體驗 (UX)、意圖理解、購物流程  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#3)

段落 #4【DEMO #2：偵測與紀錄使用者滿意度】  
摘要：作者嘗試在「安德魯小舖 GPTs」中，讓 AI 主動從對話中推論使用者心情、紀錄評分與原因，同時也依照使用者習慣做個人化推薦。意在顯示 AI 能處理更深層的使用者情緒與個人化需求。  
關鍵標籤：客製化、個人化推薦、情感分析、滿意度  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#4)

段落 #5【AI UX 的降維打擊】  
摘要：作者呼應前面示範，說明以 LLM 解析自然語言意圖，比起傳統介面設計更能直接捕捉使用者需求。但仍強調不會替代既有 UI/UX，而是帶來另一種全新設計維度。  
關鍵標籤：UX、自然語言解析、維度、互補  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#5)

段落 #6【軟體開發的樣貌轉變：不再只是精確計算】  
摘要：作者指出軟體開發長期以「精確」演算法為主，如 CRUD、狀態機、邏輯判斷等；現在加入 AI 後，有更多需要「意圖理解」與「不確定性」的空間，必須懂得把二者適度結合。  
關鍵標籤：演算法、計算、意圖理解、不確定性  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#6)

段落 #7【API 設計品質的重要：AI DX】  
摘要：呼應前幾年強調的 API First，作者再次強調 API 設計不能只為了眼前 UI 或特定用例。若要給 AI 代理人使用，需嚴謹考慮狀態機、原子操作、授權控制等，避免 AI 誤用造成資料混亂。  
關鍵標籤：API First、AI DX、狀態機、授權控制  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#7)

段落 #8【AI 開發人員必備基礎】  
摘要：作者整理未來開發人員需掌握的四大能力：  
1) 良好 API First 設計  
2) 架構規劃 AI 的定位  
3) 了解 AI 運作原理 (Embedding, Prompt, VectorDB, RAG)  
4) 常見應用模式 (RAG、推薦系統)  
關鍵標籤：架構規劃、Prompt Engineering、RAG、微服務  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#8)

段落 #9【Prompt Engineering 的三大範例】  
摘要：作者引用他人文章，舉例「基本型」對話、指定輸出 JSON 格式 (Json Mode)、Function Calling，以及進階 Workflow。從中強調如何引導 LLM 正確回傳結構化內容，或正確呼叫外部 API。  
關鍵標籤：Prompt、Json Mode、Function Calling、Workflow  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#9)

段落 #10【DEMO #3：Copilot 架構實作】  
摘要：作者用 .NET Console + Semantic Kernel 示範「安德魯小舖 Copilot」，把 LLM 當副駕駛，主要邏輯仍由 Controller 負責，但可在操作中即時向 AI 請求協助。此種 AI 輔助 (Copilot) 被視為介於傳統程式與 Agent 完全接管之間的過渡模式。  
關鍵標籤：Copilot、Semantic Kernel、.NET、過渡模式  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#10)

段落 #11【DEMO #4：RAG 與安德魯的部落格 GPTs】  
摘要：作者使用 RAG 模型結合個人文章庫的檔案索引，並讓 LLM 擔任最終回答器，實現能查詢部落格特定內容並進行總結的機制。強調未來系統若有龐大知識庫，就能用類似思路加上 AI 搜索、整合。  
關鍵標籤：RAG、知識庫、部落格、向量資料庫  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#11)

段落 #12【零售業 AI 應用情境】  
摘要：引用 Happy 的分享，強調零售業在不同銷售場景可透過 Agent (AI) 與後端 Engine (各種服務) 合作，掌握消費者心理與提升銷售體驗。作者認為這也與「API First + AI First」模式高度吻合。  
關鍵標籤：零售業、Agent、Engine、銷售場景  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#12)

段落 #13【部署管線與基礎建設】  
摘要：作者引用 DevOpsDays 2021 所述的三大 Pipeline（App/Config/Environment），認為在 AI 時代應再加上一條專門針對「模型、數據與算力部署」的 Pipeline，才算完整。  
關鍵標籤：AI Pipeline、GitOps、環境部署、DevOps  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#13)

段落 #14【結語】  
摘要：作者強調「要往 AI First 邁進，從 API First 出發的基礎必不可少」。AI 越成熟，未來應用會越多，開發團隊要先打好架構、流程、基礎建設與測試驗證面向的底子，才能在 AI 時代真正發揮競爭力。  
關鍵標籤：AI First、競爭力、未來展望、總結  
(來源: 2024-07-20-devopsdays-keynote.md, 段落#14)

2. Q&A 視角 (Question & Answer)

以下列出 8 組可能的讀者問題與回答，並附上對應來源標記。

Q1: 為何「AI First」需要特別強調「API First」的概念？
A1: 因為 AI 代理人要能夠正常呼叫後端服務，需依賴良好的 API 設計；若 API 不完善或狀態沒管理好，AI 容易產生錯誤操作或造成資料污染。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#7)

Q2: 「安德魯小舖 GPTs」如何替用戶找商品並結帳？
A2: LLM 從對話推論用戶需求，再依據預先提供的 API 規格呼叫查詢商品、加入購物車、結帳等動作，最後回覆結果給用戶。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#3)

Q3: 對話式 AI 介面是否會取代傳統 UI/UX？
A3: 文章認為二者是「不同維度」的做法；AI 能在理解意圖、主動操作上帶來新體驗，但亦需傳統 UI/UX 補足精準與效率，兩者互補。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#5)

Q4: 在軟體開發中，AI 擅長處理哪類問題？不適合處理哪類？
A4: AI 擅長處理語言、推論、不確定性等；不適合做需要完全精準、穩定的計算或邏輯，應搭配傳統演算法與後端服務。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#6)

Q5: Prompt Engineering 有哪些常見的做法？
A5: 常見包括「基本型對話提示」、「指定輸出結構(JSON Mode)」、「函式呼叫(Function Calling)」、以及更複雜的 Workflow。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#9)

Q6: 何謂 Copilot 模式？
A6: Copilot 模式指的是保留既有的流程與 UI，由 AI 只在使用者需要時出來協助，如同「副駕駛」，並非全程以 AI 為主導。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#10)

Q7: RAG (檢索增強生成) 的核心流程是什麼？
A7: 先以向量索引等方式檢索相關內容，再把檢索到的文本餵給 LLM 做最後的總結與回答，可有效解決 LLM 訓練知識盲區的問題。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#11)

Q8: 加入 AI 之後的軟體部署流程需要改變嗎？
A8: 作者提出在原本應用程式、配置、環境 3 條 pipeline 外，再增加 AI (模型/數據/算力) 的專屬部署管線，形成 4 條並行的方式才能更好管理。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#13)

3. Problem–RootCause–Resolution–Example 視角

以下列出 4 組問題結構，並附上來源。

(1)
Problem: 傳統 UI/UX 難以準確掌握使用者複雜的意圖或情感。  
Root Cause: UI 設計多依賴統計行為數據與固定流程，無法因個人需求與語言表達的彈性而即時調整。  
Resolution: 導入 LLM，建立對話式介面或 Copilot 機制，讓 AI 直接解析自然語言以理解使用者需求。  
Example: 「安德魯小舖 GPTs」在對話中自動推薦商品、結帳、偵測滿意度。(來源: 2024-07-20-devopsdays-keynote.md, 段落#2~#5)

(2)
Problem: 內部 API 只針對前端場景設計，欠缺對 domain 狀態與授權的嚴謹管控。  
Root Cause: 開發者以 UI 為中心思考，未仔細制定狀態機與對應 API，導致難以給其他服務或 AI 安全使用。  
Resolution: 採用 API First，從 domain 狀態機出發定義必要操作，明確設計 SCOPE 與授權層級，並撰寫完備文件。  
Example: 文中提到設計訂單狀態機、原子轉移 API，使 AI 無法輕易破壞資料。(來源: 2024-07-20-devopsdays-keynote.md, 段落#7)

(3)
Problem: 開發者不熟悉 LLM 的運作，AI 返回結果往往沒按照預期格式或流程。  
Root Cause: 缺乏 Prompt Engineering 觀念，沒有在系統呼叫階段清晰定義輸出格式或函式參數。  
Resolution: 使用 JSON Mode 或 Function Calling 等技術，讓 LLM 輸出符合結構化需求，並在多步驟工作裡拆解成多次呼叫。  
Example: 文章範例：以 prompt 要求以 JSON 格式輸出，並指定欄位名稱，或透過 GPTs function calling 完成查詢。(來源: 2024-07-20-devopsdays-keynote.md, 段落#9)

(4)
Problem: 面對大量內部知識或文件，AI 回答易受訓練資料不足而出錯。  
Root Cause: LLM 固有的模型缺陷：未必包含組織內部的新文件或特定知識。  
Resolution: 導入 RAG 流程，先行檢索企業內部資料庫，再由 LLM 結合檢索結果做最終回答。  
Example: 「安德魯的部落格 GPTs」利用向量索引找出文章片段，供 LLM 統整成較完整回答。(來源: 2024-07-20-devopsdays-keynote.md, 段落#11)

4. PARA 視角 (Project, Area, Resource, Archive)

以下嘗試歸納文中可能可分入 PARA 四類的要點。

(1) Project  
- 「安德魯小舖 GPTs」：作者個人 PoC，嘗試用對話式介面整合購物流程。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#3~#5)  
- 「安德魯的部落格 GPTs」：作者以 RAG 方式打造的專屬知識庫查詢系統。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#11)

(2) Area (長期關注領域)  
- AI First 與軟體開發：將 LLM 視為應用程式核心元件的架構設計與實踐。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#2)  
- DevOps / Pipeline：作者在 DevOpsDays 累積的多場演講內容，關注「如何持續交付並融入 AI 部署」。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#7, #13)

(3) Resource (工具、方法、技術參考)  
- OpenAI / ChatGPT function calling、Semantic Kernel、RAG、VectorDB (向量資料庫) 等。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#9~#11)  
- Prompt Engineering 技巧：基本型對話、JSON Mode、Function Calling、Workflow。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#9)

(4) Archive (歷史記錄、補充資訊)  
- 作者於 DevOpsDays 2021、2022、2023、2024 的歷年議程與心得文連結。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#1)  
- 生成式 AI 年會、零售業 AI 產業應用的簡報、共筆資訊。 (來源: 2024-07-20-devopsdays-keynote.md, 段落#12)

