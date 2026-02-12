from fastapi import FastAPI
from src.api.routers import credito

def register_routes(app: FastAPI):
    app.include_router(credito.router, prefix="/credito", tags=["Crédito"])
