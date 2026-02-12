from pydantic import BaseModel

class ClienteInput(BaseModel):
    person_age: int #idade
    person_income: float #renda
    person_emp_length: float #tempo empregada
    loan_amnt: float #valor do empréstimo
    loan_int_rate: float #taxa do empréstimo
    loan_percent_income: float #divisão do empréstimo pela renda
    cb_person_cred_hist_length: float # histórico de crédito
    person_home_ownership: str #Situação do imóvel
    loan_intent: str #Finalidade do empréstimo
    loan_grade: str #Classificação do empréstimo
    cb_person_default_on_file: str #histórico de crédito

class RiscoOutput(BaseModel):
    risco: float
