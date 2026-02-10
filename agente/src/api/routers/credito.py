from fastapi import APIRouter
from src.models.schemas import ClienteInput, RiscoOutput
from src.config.ml import model
import pandas as pd

router = APIRouter()

@router.post("/avaliar", response_model=RiscoOutput)
def avaliar_credito(cliente: ClienteInput):
    X = pd.DataFrame([{
        "person_age": cliente.person_age,
        "person_income": cliente.person_income,
        "person_emp_length": cliente.person_emp_length,
        "loan_amnt": cliente.loan_amnt,
        "loan_int_rate": cliente.loan_int_rate,
        "loan_percent_income": cliente.loan_percent_income,
        "cb_person_cred_hist_length": cliente.cb_person_cred_hist_length,
        "person_home_ownership": cliente.person_home_ownership,
        "loan_intent": cliente.loan_intent,
        "loan_grade": cliente.loan_grade,
        "cb_person_default_on_file": cliente.cb_person_default_on_file
    }])

    risco = float(model.predict_proba(X)[0][1])
    return {"risco": risco}
