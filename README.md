# ConnectNow ⚡️

**ConnectNow** is a real-time chat app built with ASP.NET Core using SignalR and ReactJS. Messages are stored in memory. Ideal for practicing real-time communication, custom middleware, CORS setup, and frontend integration.

---

## ⚙️ Main Features

- 💬 Real-time message sending and receiving
- 🔄 Automatic message updates via SignalR
- 🧠 In-memory message storage (no database)
- 🧱 Custom middleware for request logging
- 🔓 CORS configuration for frontend access
- 📄 API documentation with Swagger

---

## 🛠️ Technologies

- **Frontend**: ReactJS (Vite)
- **Backend**: ASP.NET Core 8 (Web API)
- **Real-time**: SignalR
- **Documentation**: Swagger
- **Storage**: InMemory
- **Others**: CORS, Middleware

---

## 🚧 In Development

We are currently focusing on the MVP with:

- Full integration between React frontend and SignalR backend
- Bidirectional real-time messaging
- Custom request logging middleware
- Folder-based project organization
- Clear API documentation with Swagger

## 🗂️ Project Structure

```bash
CONNECTNOW/
CONNECTNOW│
├── .github/                        # CI/CD configuration using GitHub Actions
│   ├── workflows/
│   │   └── (e.g., backend.yml)     # Automated build/test/deploy workflows
│   │
│   └── workflows.md                # Explanation of CI/CD pipelines
│
├── .vscode/                        # VSCode environment settings (e.g., launch.json, settings.json)
│
├── doc/                            # General project documentation
│   ├── blueprint/                  # Technical requirements and documentation
│   └── visual/                     # Diagrams, wireframes, flowcharts, etc. (to be added)
│
├── src/                            # Main source code
│   ├── backend/                    # ASP.NET Core project (API + SignalR)
│   │   ├── ConnectNow/             # Application logic, Hubs, Middleware, Services
│   │   └── backend.md              # Documentation about backend architecture and tech stack
│   │
│   ├── frontend/                   # ReactJS project (via Vite)
│   │   ├── connectnow/             # Frontend code (components, views, SignalR connection)
│   │   └── frontend.md             # Stack explanation and frontend structure
│
├── .gitattributes                  # Git file attribute settings (e.g., line endings, language hints)
├── .gitignore                      # Files/folders ignored by Git (e.g., bin/, obj/, node_modules/)
├── LICENSE                         # Project license (MIT, permissive)
├── README.md                       # Project introduction, features, structure, and how to run
└── ConnectNow.sln                  # Visual Studio solution file (.NET)
