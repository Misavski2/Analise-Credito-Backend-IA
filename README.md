# 📊 Auditoria de Crédito Bancário

Sistema para análise e auditoria de crédito bancário utilizando:

* Backend em **.NET (C#)**
* Agente de Inteligência Artificial em **Python**
* Modelo de Machine Learning treinado (Random Forest)

---

## 📁 Estrutura do Projeto

```
AnaliseCredito/
│
├── backend/                 # API em C#
│
├── agente/                  # Agente de IA
│   ├── model/
│   │   └── credit_rf_model.pkl
│   ├── src/
│   │   └── config/
│   │       └── ml.py
│   ├── requirements.txt
│   └── README.md
│
└── README.md
```

---

# 🚀 Como executar o projeto

---

## 🔹 1️⃣ Clonar o repositório

```bash
git clone <url-do-repositorio>
cd AnaliseCredito
```

---

# 🧠 Agente de IA (Python)

## 🔧 Requisitos

* Python **3.11**
* pip

---

## 🏗 Criar ambiente virtual

Na pasta `agente/`:

```bash
cd agente
py -3.11 -m venv venv
```

Ativar o ambiente:

### Windows (PowerShell)

```bash
venv\Scripts\Activate
```

### Linux/Mac

```bash
source venv/bin/activate
```

---

## 📦 Instalar dependências

```bash
pip install -r requirements.txt
```

---

## ▶ Executar o agente

```bash
python src/config/ml.py
```

---

# 💻 Backend (.NET)

## 🔧 Requisitos

* .NET SDK instalado

---

## ▶ Executar a API

Na pasta do backend:

```bash
dotnet restore
dotnet run
```

---

# 🔀 Fluxo de Branches

* `main` → versão estável
* `dev` → integração do time
* `feature/*` → branches individuais dos membros

Fluxo recomendado:

```bash
git checkout -b feature/nome-da-feature
git commit -m "feat: descrição clara da alteração"
git push origin feature/nome-da-feature
```

Merge para `dev` via Pull Request.

---

# 🧪 Modelo de Machine Learning

* Algoritmo: **Random Forest**
* Arquivo treinado: `credit_rf_model.pkl`
* Responsável pela análise de crédito com base nos dados fornecidos pelo backend.

---

# 🛠 Boas Práticas

* Não versionar a pasta `venv/`
* Sempre usar Python 3.11
* Manter `requirements.txt` atualizado
* Usar commits semânticos:

  * `feat:` nova funcionalidade
  * `fix:` correção
  * `chore:` ajustes internos
  * `docs:` documentação

---

# 👥 Equipe Monster com Leite

* Daniel
* Luann
* Jorge
* Mizael

---

