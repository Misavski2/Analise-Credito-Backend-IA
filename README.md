# Sistema de Auditoria de Crédito (Integração C# + IA)

Projeto Fullstack composto por uma API .NET (Backend) e um Agente Inteligente em Python (IA).

---

## Como Rodar (Guia Rápido)

⚠️ **IMPORTANTE:** Siga a ordem exata abaixo para evitar erros de conexão.

### 1. Iniciar o Cérebro (Python AI) 🧠
Abra um terminal na pasta `agente` e execute:

```bash
cd agente

# Ativar ambiente virtual
# Windows:
.\venv\Scripts\Activate

# Linux/Mac:
source venv/bin/activate

# Se for a primeira vez, instale as dependências:
pip install -r requirements.txt
# (Ou manualmente: pip install fastapi uvicorn pydantic scikit-learn==1.6.1 pandas joblib)

# Rodar o servidor na porta 8000
python -m uvicorn src.main:app --reload --port 8000
✅ Aguarde aparecer: Uvicorn running on http://127.0.0.1:8000

2. Iniciar o Backend (C# .NET) 
Abra outro terminal na raiz do projeto e execute:

Bash
cd backend/CsharpBackend

# PASSO CRÍTICO: Criar o Banco de Dados localmente
dotnet tool install --global dotnet-ef
dotnet restore
dotnet ef database update

# Rodar a API
dotnet watch run
✅ Aguarde aparecer: Now listening on: http://localhost:5295

3. Como Testar (Via Postman) 
URL: http://localhost:5295/api/analise

Método: POST

Body (JSON):

JSON
{
  "nome": "Cliente Teste",
  "cpf": "123.456.789-00",
  "renda": 5000,
  "valorSolicitado": 2000,
  "parcelas": 12,
  "idade": 30
}
Resultado Esperado: O C# vai consultar o Python e devolver um JSON com "aprovado": true/false, "score" e "mensagem".
