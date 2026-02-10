from fastapi import FastAPI
from src.api.routers import credito

app = FastAPI(title="Agente de Risco de Crédito")

app.include_router(credito.router)