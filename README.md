# Credit Audit System (C# + AI Integration)

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54)
![FastAPI](https://img.shields.io/badge/FastAPI-005571?style=for-the-badge&logo=fastapi)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

Full-stack project consisting of a **.NET API (Backend)** and an **Intelligent Agent in Python (AI)**.

---

## 🚀 How to Run (Quick Guide)

⚠️ **IMPORTANT:** Follow the exact order below to avoid connection errors.

### 1. Start the Brain (Python AI) 🧠
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
