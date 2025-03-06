Case 1: 微服務資料一致性處理
- Problem: 如何在微服務架構下確保資料的一致性。
- RootCause: 微服務環境中存在多個獨立的服務，這導致資料的一致性和協調變得複雜。
- Resolution: 使用分散式交易控制和事件驅動架構來解決，確保只有一個服務能成功執行狀態轉移，其它收到錯誤訊息停止。
- Example: 用C#的event機制發射狀態改變事件，結合message queue和worker處理訊息。

Case 2: 部落格文章的高效檢索
- Problem: 如何讓讀者快速查找與應用部落格文章內容。
- RootCause: 傳統搜尋只能依靠關鍵詞，語意檢索能力有限。
- Resolution: 透過GPTs結合Kernel Memory，以文本向量化和語意檢索增強搜尋能力。
- Example: 根據問題向量化文本並從Vector資料庫中檢索相應片段，GPTs將檢索結果彙整給使用者。

Case 3: 部落格系統的資料組織
- Problem: 持續演變的部落格系統增加了查找資訊的難度。
- RootCause: 不同系統的轉換和升級使得資料結構多樣化且不易追溯。
- Resolution: 使用Kernel Memory將文章摘要、標籤和分類資料附加到向量化資料中，增加檢索效率。
- Example: 使用TagCollection在文章內容上標註標籤、分類和其他關聯資訊，便於檢索和管理。