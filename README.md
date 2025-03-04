# AndrewDemo.DevAIAPPs

這是我介紹在你的服務內使用 AI (API) 用法的說明範例。
在 APP 內使用 AI 有幾種常見的 design pattern, 這裡我會介紹幾種常見的用法，包含:

1. 基本應用: chat completion
1. 結構化輸出: json mode
1. 呼叫外部程式: tool use / function calling
1. 綜合應用: RAG

這些應用案例，為了說明背後運作的方式，我分別用了三種不同的使用方式:


**Project**: UseOpenAI_SDK  

1. 直接用 http request 呼叫 [openai chatcompletion api](https://platform.openai.com/docs/api-reference/chat)
1. 使用 [openai .net sdk](https://github.com/openai/openai-dotnet)

**Project**: UseMicrosoft_SemanticKernel  

1. 使用 [microsoft semantic kernel](https://github.com/microsoft/semantic-kernel/)

**Project**: UseMicrosoft_KernelMemoryPlugin  

RAG 的進階應用, 包含 [microsoft kernel memory](https://github.com/microsoft/kernel-memory) 提供給 semantic kernel 使用的 memory plugin, 我獨立一個專案來示範
我也提供了一個對照組，用 plugins 來呼叫 [Bing Web Search API](https://learn.microsoft.com/en-us/bing/search-apis/bing-web-search/overview)







# 環境設置 Setup - User Secrets

這份範例，我都使用 OpenAI API 當作 LLM provider. 對應的 APIKEY 請自行設定 user secret.
以下是需要設定的項目:

三個 project(s) 我用的 user secret 名稱都維持一至, 你可以共用同一組 user secret 沒問題。
以下是我範例會用到的結構:

```json

{
  "OpenAI:ApiKey": "sk-XXXXXXXXXXXXX",
  "OpenAI:OrgId": "org-XXXXXXXXXXXXX",
  "KernelMemory:ApiKey": "XXXXXXXXXXXXXXX",
  "BingSearch:ApiKey": "XXXXXXXXXXXXXX"
}

```

按照順序說明:

**OpenAI:ApiKey**:  
存取 openai api 使用. 會用到 4o, 4o-mini, o1 這三個模型。  

- [X] Project: UseOpenAI_SDK
- [X] Project: UseMicrosoft_SemanticKernel
- [X] Project: UseMicrosoft_KernelMemoryPlugin

**OpenAI:OrgId**:  
Optional, 管理用途，存取 OpenAI 服務時，標示 OrgID，可用來按照不同 orgid 指派 quota。  

- [ ] Project: UseOpenAI_SDK
- [ ] Project: UseMicrosoft_SemanticKernel
- [ ] Project: UseMicrosoft_KernelMemoryPlugin

**KernelMemory:ApiKey**:  
存取你自己架設 Microsoft Kernel Memory 時需要使用的 APIKEY  
- [ ] Project: UseOpenAI_SDK
- [ ] Project: UseMicrosoft_SemanticKernel
- [X] Project: UseMicrosoft_KernelMemoryPlugin


**BingSearch:ApiKey**:  
存取 Bing Search Service 使用的 APIKEY。  
若要執行 Example02, 請先到 Azure 申請 Bing Search Service APIKEY.  

- [ ] Project: UseOpenAI_SDK
- [ ] Project: UseMicrosoft_SemanticKernel
- [X] Project: UseMicrosoft_KernelMemoryPlugin
	- [X] Example02: RAG with Search Plugins


# 服務架設: Microsoft Kernel Memory

只要兩個步驟，你就可以架設自己的 Microsoft Kernel Memory 服務。
(1), 按照 [官方的說明](https://github.com/microsoft/kernel-memory/tree/main?tab=readme-ov-file#kernel-memory-docker-image), 執行 setup, 問答過程中收集到的設定資訊, 都會存在 appsettings.json。用 docker run 就可以啟動服務
(2), 由於還要搭配 qdrant 向量資料庫, 因此我自己弄了一份 docker-compose.yaml, 方便依次建置整套環境, 有需要的朋友可以採用我的懶人包。

推薦在 WSL2 環境下執行, 這樣可以避免一些環境設定的問題。不過這個範例會用到向量資料庫 qdrant, 避免踩到 WSL2 的 IO 效能問題的地雷 (IO 效能差距到 20x 之譜), 請參考我的文章有完整說明:

* [用 WSL + VSCode 重新打造 Linux 開發環境](https://columns.chicken-house.net/2024/11/11/working-with-wsl/)