# Finance Goals

Software para gerenciamento de objetivos de financeiros, similar a caixinha do Nubank. Realizado com o propósito de aperfeiçar minhas habilidades na construção de APIs.

## Regras de negócio

- [ ] Transação deve ser feita com até duas casas decimais de precisão, e não pode ser negativa;

## Entidades
### Goal

- Id (int / Guid)
- TItle (string)
- TargetAmount (decimal)
- Deadline (datetime) (opcional)
- IdealQuantity (decimal) (opcional)
- Status (Enum) (InProgress, Finished, Canceled, Paused)
- Transations (coleção de Transação)
- CreatedAt (datetime)
- IsDeleted (bool)

### Transaction

- Id (int / Guid)
- Quantity (decimal)
- Kind (Enum - Depósito ou Saque)
- TransactionDate (datetime) (pode ser hoje ou de uma data passada)
- CreatedAt (datetime)
- IsDeleted (bool)


## Conceitos aplicados

- [ ]   asdsa
- [ ] as sadsaa