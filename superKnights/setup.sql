CREATE TABLE knights(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  name varchar(255) comment ''
) default charset utf8 comment '';
CREATE TABLE quests(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  title varchar(255),
  completed TINYINT DEFAULT 0,
  details varchar(255)
) default charset utf8;
CREATE TABLE knight_quest(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  questId int NOT NULL COMMENT 'FK: Quest',
  knightId int NOT NULL COMMENT 'FK: Knight',
  FOREIGN KEY(questId) REFERENCES quests(id) ON DELETE CASCADE,
  FOREIGN KEY(knightId) REFERENCES knights(id) ON DELETE CASCADE
) default charset utf8;
INSERT INTO
  knight_quest (knightId, questId)
VALUES(1, 1);
Select
  *
FROM
  knight_quest;
SELECT
  k.*,
  kq.*
FROM
  knight_quest kq
  JOIN knights k ON k.id = kq.knightId
WHERE
  kq.questId = @questId;