## Setup - Claude Desktop

Claude Desktop 的設定檔案路徑在:


請確保有加入 demo 的 mcp servers 設定。
以下是我的本機設定案例:

1. mcp server name: "demo"
1. mcp server 啟動 command: 我直接填編譯好的可執行檔路徑 (留意反斜線)
1. mcp server 啟動 arguments: 我的執行檔不需要參數, 保持空陣列

每個人的情況不同，可能會有額外的 settings, 請別動到他, 你只要確保 "demo" 沒有重複就好



path: C:\Users\{username}\AppData\Roaming\Claude\claude_desktop_config.json

```json

{

    "mcpServers": {
        "demo": {
            "command": "D:\\CodeWork\\github.com\\AndrewDemo.DevAIApps\\KernelMemory_MCPServer\\bin\\Debug\\net8.0\\KernelMemory_MCPServer.exe",
            "args": []
        }
    }

}

```



## Manual Test MCP server

MCP server 我採用 Stdio Transport, 你可以在 console 直接輸入 jsonrpc 的 payload.
以下是我從 logs 擷取出來的 request payload:

```

{"method":"initialize","params":{"protocolVersion":"2024-11-05","capabilities":{},"clientInfo":{"name":"claude-ai","version":"0.1.0"}},"jsonrpc":"2.0","id":0}
{"method":"notifications/initialized","jsonrpc":"2.0"}
{"method":"resources/list","params":{},"jsonrpc":"2.0","id":1}
{"method":"tools/list","params":{},"jsonrpc":"2.0","id":2}


```


我用這段 prompt, 來測試 Claude Desktop 怎麼從我的 mcp server 取得資訊後進行 RAG 彙整答案給我:

```

search andrew's blog, tell me all about "SDK design" concepts that andrew says...

```

