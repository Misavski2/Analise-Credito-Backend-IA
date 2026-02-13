Markdown
# Credit Audit System (C# + AI Integration)

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54)
![FastAPI](https://img.shields.io/badge/FastAPI-005571?style=for-the-badge&logo=fastapi)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

Full-stack project consisting of a **.NET API (Backend)** and an **Intelligent Agent in Python (AI)**.

---

## How to Run (Quick Guide)

⚠️ **IMPORTANT:** Follow the exact order below to avoid connection errors.

### 1. Start the Brain (Python AI) 
Open a terminal in the `agente` folder and run:

```bash
cd agente

# Activate virtual environment
# Windows:
.\venv\Scripts\Activate

# Linux/Mac:
source venv/bin/activate

# Install dependencies:
pip install -r requirements.txt

# Run the server on port 8000
python -m uvicorn src.main:app --reload --port 8000
 Wait for the message: Uvicorn running on http://127.0.0.1:8000

2. Start the Backend (C# .NET) 
Open another terminal at the project root and run:

Bash
cd backend/CsharpBackend

# CRITICAL STEP: Create the local Database
dotnet tool install --global dotnet-ef
dotnet restore
dotnet ef database update

# Run the API
dotnet watch run
 Wait for the message: Now listening on: http://localhost:5295

3. How to Test (Via Postman) 
URL: http://localhost:5295/api/analise

Method: POST

Body (JSON):

JSON
{
  "nome": "Test Client",
  "cpf": "123.456.789-00",
  "idade": 30,
  "renda": 5000,
  "valorSolicitado": 2000,
  "parcelas": 12,
  "tempoEmprego": 2.5,
  "finalidade": "PERSONAL",
  "tipoMoradia": "RENT",
  "anosHistoricoCredito": 5,
  "jaDeuCalote": "N"
}
Expected Result: The C# backend will consult the Python AI and return a JSON containing "aprovado": true/false, "score", and a "mensagem".
