SELECT R.ID,
                                    R.SALA_ID,
                                    R.FUNCIONARIO_ID
                                    DATA_HORA_INICIAL,
                                    DATA_HORA_FINAL,
                                    F.NOME,
                                    F.CARGO,
                                    F.RAMAL,
                                    S.NOME,
                                    S.QUANTIDADE_LUGARES FROM RESERVA R
                                    INNER JOIN FUNCIONARIO F ON (F.ID = R.FUNCIONARIO_ID)
                                    INNER JOIN SALA S ON (S.ID = R.SALA_ID)

                                    SELECT * FROM RESERVA
INSERT RESERVA VALUES (1, 1, '2022-09-04', '2022-09-05') 