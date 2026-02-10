import joblib
from pathlib import Path

MODEL_PATH = Path(__file__).resolve().parents[2] / "model" / "credit_rf_model.pkl"

model = joblib.load(MODEL_PATH)