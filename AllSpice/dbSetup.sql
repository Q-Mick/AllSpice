CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  category VARCHAR(255) NOT NULL DEFAULT "misc",
  img VARCHAR(500) NOT NULL,
  instructions VARCHAR(500) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE
    ingredients(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL DEFAULT "1",
        recipeId INT NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    favorites(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        accountId VARCHAR(255) NOT NULL COMMENT'account id',
        recipeId INT NOT NULL COMMENT'recipe object id',
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
collections(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    recipeId INT NOT NULL,
    accountId VARCHAR(255) NOT NULL,
    FOREIGN KEY(recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
    FOREIGN KEY(accountId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

-- INSERT INTO ingredients
-- (name, quantity, recipeId)
-- VALUES

SELECT * FROM ingredients
WHERE `recipeId` = 32;
;

INSERT INTO
    favorites (accountId, recipeId)
VALUES (
        '648b6d84e289b1b37944ac30',
        6
    );
SELECT act.*
FROM favorites favs
    JOIN accounts act ON act.id = favs.accountId
    JOIN recipes recipe ON recipe.id = favs.recipeId;