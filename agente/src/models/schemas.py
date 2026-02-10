from pydantic import BaseModel

class ClienteInput(BaseModel):
    person_age: int
    person_income: float
    person_emp_length: float
    loan_amnt: float
    loan_int_rate: float
    loan_percent_income: float
    cb_person_cred_hist_length: float
    person_home_ownership: str
    loan_intent: str
    loan_grade: str
    cb_person_default_on_file: str

class RiscoOutput(BaseModel):
    risco: float
