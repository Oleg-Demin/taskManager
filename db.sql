-- Данная БД служит всего лишь примером, и необходима только для наглядности

-- DROP DATABASE taskManagerSQL;
-- CREATE DATABASE taskManagerSQL;

DROP TABLE IF EXISTS tasks;
DROP TABLE IF EXISTS statuses;

CREATE TABLE IF NOT EXISTS statuses
(
    status_id SERIAL PRIMARY KEY,
    status_name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS tasks
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(255) NOT NULL,
    status_id INT REFERENCES statuses (status_id)
        ON DELETE restrict ON UPDATE cascade NOT null
);

INSERT INTO statuses (status_name) VALUES
('Создана'),
('В работе'),
('Завершена');

INSERT INTO tasks (name, description, status_id) VALUES
('Задача 1', 'Описание 1', 1),
('Задача 2', 'Описание 2', 2),
('Задача 3', 'Описание 3', 3);

SELECT * FROM statuses;
SELECT * FROM tasks;

SELECT tsk.name, tsk.description, sts.status_name FROM tasks AS tsk
    JOIN statuses AS sts ON (tsk.status_id = sts.status_id);
