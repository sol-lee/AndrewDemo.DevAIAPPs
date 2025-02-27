Case 1: 智慧化資料檢索的實施
- Problem: 如何在應用程式中實現智慧化的資料檢索？
- RootCause: 傳統資料檢索方式（如關鍵字搜索）無法滿足複雜語意查詢的需求。
- Resolution: 利用RAG技術，結合LLM和向量資料庫實現語意檢索。
- Example: 作者透過Kernel Memory和GPTs，開發了一個部落格檢索系統，能夠進行精確的語意性內容查找。

Case 2: 向量化資料搜尋技術的應用
- Problem: 如何將資料轉換為可進行語意比對的格式？
- RootCause: 傳統資料格式難以進行複雜的語意比對。
- Resolution: 施行資料的chunking和embedding，將內容轉化為向量形式，並利用向量資料庫實現檢索。
- Example: 作者使用text-embedding模型，將部落格文章分段並嵌入向量空間進行儲存和檢索。

Case 3: 使用AI進行內容歸納與分析
- Problem: 如何自動化內容的歸納和分析，以提高使用者體驗。
- RootCause: 人工作業迫於龐大的資料量而難以有效運作。
- Resolution: 利用AI和RAG技術搭建系統，讓AI擔當內容分析的角色。
- Example: 作者開發了"安德魯的部落格GPTs"，能迅速回應使用者問題，並附上相關文章資訊。