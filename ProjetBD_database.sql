DROP VIEW V_UPCOMING_EVENTS;
DROP VIEW V_ADULT_EVENTS;
DROP TABLE LOGS;
DROP TABLE EVENT_PLAYER;
DROP TABLE BOARDGAME_EVENT;
DROP TABLE BOARDGAMES;
DROP TABLE EVENTS;
DROP TABLE PLAYERS;
DROP SEQUENCE SEQ_LOGS;
DROP SEQUENCE SEQ_EVENT_PLAYER;
DROP SEQUENCE SEQ_BOARDGAME_EVENT;
DROP SEQUENCE SEQ_BOARDGAMES;
DROP SEQUENCE SEQ_EVENTS;
DROP SEQUENCE SEQ_PLAYERS;

CREATE TABLE PLAYERS(
	ID NUMBER PRIMARY KEY,
	FIRSTNAME VARCHAR(50),
	LASTNAME VARCHAR(50)
);

CREATE SEQUENCE SEQ_PLAYERS START WITH 1 INCREMENT BY 1 NOCYCLE;

CREATE OR REPLACE TRIGGER TRIG_PLAYERS
BEFORE INSERT ON PLAYERS
REFERENCING OLD AS OLD NEW AS NEW
FOR EACH ROW
	WHEN (NEW.ID IS NULL)
BEGIN
   SELECT SEQ_PLAYERS.NEXTVAL INTO :NEW.ID FROM DUAL;
END;
/

CREATE TABLE EVENTS(
	ID NUMBER PRIMARY KEY,
	NAME VARCHAR(50),
	DESCRIPTION VARCHAR(256),
	DATESTART DATE DEFAULT (sysdate)
);

CREATE SEQUENCE SEQ_EVENTS START WITH 1 INCREMENT BY 1 NOCYCLE;

CREATE OR REPLACE TRIGGER TRIG_EVENTS
BEFORE INSERT ON EVENTS
REFERENCING OLD AS OLD NEW AS NEW
FOR EACH ROW
	WHEN (NEW.ID IS NULL)
BEGIN
   SELECT SEQ_EVENTS.NEXTVAL INTO :NEW.ID FROM DUAL;
END;
/

CREATE TABLE BOARDGAMES(
	ID NUMBER PRIMARY KEY,
	NAME VARCHAR(50),
	MINIMUM_PLAYER_NUMBER NUMBER(2),
	MAXIMUM_PLAYER_NUMBER NUMBER(2),
	MINIMUM_AGE NUMBER(2),
	AVERAGE_GAME_TIME NUMBER(3)
);

CREATE SEQUENCE SEQ_BOARDGAMES START WITH 1 INCREMENT BY 1 NOCYCLE;

CREATE OR REPLACE TRIGGER TRIG_BOARDGAMES
BEFORE INSERT ON BOARDGAMES
REFERENCING OLD AS OLD NEW AS NEW
FOR EACH ROW
	WHEN (NEW.ID IS NULL)
BEGIN
   SELECT SEQ_BOARDGAMES.NEXTVAL INTO :NEW.ID FROM DUAL;
END;
/

CREATE TABLE BOARDGAME_EVENT(
	ID NUMBER PRIMARY KEY,
	BOARDGAME_ID NUMBER CONSTRAINT FK_BG_EVENT_BOARDGAME_ID REFERENCES BOARDGAMES(ID) ON DELETE CASCADE,
	EVENT_ID NUMBER CONSTRAINT FK_BG_EVENT_EVENT_ID REFERENCES EVENTS(ID) ON DELETE CASCADE
);

CREATE SEQUENCE SEQ_BOARDGAME_EVENT START WITH 1 INCREMENT BY 1 NOCYCLE;

CREATE OR REPLACE TRIGGER TRIG_BOARDGAME_EVENT
BEFORE INSERT ON BOARDGAME_EVENT
REFERENCING OLD AS OLD NEW AS NEW
FOR EACH ROW
	WHEN (NEW.ID IS NULL)
BEGIN
   SELECT SEQ_BOARDGAME_EVENT.NEXTVAL INTO :NEW.ID FROM DUAL;
END;
/

CREATE TABLE EVENT_PLAYER(
	ID NUMBER PRIMARY KEY,
	PLAYER_ID NUMBER CONSTRAINT FK_EVENT_PLAYER_PLAYER_ID REFERENCES PLAYERS(ID) ON DELETE CASCADE,
	EVENT_ID NUMBER CONSTRAINT FK_EVENT_PLAYER_EVENT_ID REFERENCES EVENTS(ID) ON DELETE CASCADE
);

CREATE SEQUENCE SEQ_EVENT_PLAYER START WITH 1 INCREMENT BY 1 NOCYCLE;

CREATE OR REPLACE TRIGGER TRIG_EVENT_PLAYER
BEFORE INSERT ON EVENT_PLAYER
REFERENCING OLD AS OLD NEW AS NEW
FOR EACH ROW
	WHEN (NEW.ID IS NULL)
BEGIN
   SELECT SEQ_EVENT_PLAYER.NEXTVAL INTO :NEW.ID FROM DUAL;
END;
/

CREATE TABLE LOGS(	
	ID NUMBER PRIMARY KEY, 
	ACTION VARCHAR2(30) NOT NULL ENABLE, 
	COMMAND VARCHAR2(2000) DEFAULT NULL
);

CREATE SEQUENCE SEQ_LOGS START WITH 1 INCREMENT BY 1 NOCYCLE;

CREATE OR REPLACE TRIGGER TRIG_LOGS
BEFORE INSERT ON LOGS
REFERENCING OLD AS OLD NEW AS NEW
FOR EACH ROW
	WHEN (NEW.ID IS NULL)
BEGIN
   SELECT SEQ_LOGS.NEXTVAL INTO :NEW.ID FROM DUAL;
END;
/

/* INDEXES */
CREATE INDEX IDX_BG_AVERAGE_GAME_TIME ON BOARDGAMES(AVERAGE_GAME_TIME);
CREATE INDEX IDX_BG_MINIMUM_AGE ON BOARDGAMES(MINIMUM_AGE);
CREATE INDEX IDX_PLAYERS_LASTNAME ON PLAYERS(LASTNAME);
CREATE INDEX IDX_EVENTS_DATESTART ON EVENTS(DATESTART);
CREATE UNIQUE INDEX IDX_EVENTS_NAME_DATESTART ON EVENTS(NAME, DATESTART);
  
/* VIEWS */
CREATE VIEW V_UPCOMING_EVENTS AS 
  SELECT UPCOMING_EVENTS.*, BOARDGAMES.NAME AS BOARDGAMENAME, BOARDGAMES.MINIMUM_PLAYER_NUMBER, BOARDGAMES.MAXIMUM_PLAYER_NUMBER, BOARDGAMES.MINIMUM_AGE, BOARDGAMES.AVERAGE_GAME_TIME
  FROM (SELECT ID, NAME, DESCRIPTION, DATESTART FROM EVENTS WHERE DATESTART >= to_char(SYSDATE, 'YY-MM-DD')) UPCOMING_EVENTS 
  INNER JOIN BOARDGAME_EVENT ON BOARDGAME_EVENT.EVENT_ID = UPCOMING_EVENTS.ID
  INNER JOIN BOARDGAMES ON BOARDGAME_EVENT.BOARDGAME_ID = BOARDGAMES.ID
  ORDER BY DATESTART DESC;

CREATE VIEW V_ADULT_EVENTS AS 
  SELECT ADULT_BOARDGAMES.*, EVENTS.NAME AS EVENTNAME, EVENTS.DESCRIPTION, EVENTS.DATESTART
  FROM (SELECT ID, NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME FROM BOARDGAMES WHERE MINIMUM_AGE >= 18) ADULT_BOARDGAMES
  INNER JOIN BOARDGAME_EVENT ON BOARDGAME_EVENT.BOARDGAME_ID = ADULT_BOARDGAMES.ID
  INNER JOIN EVENTS ON EVENTS.ID = BOARDGAME_EVENT.EVENT_ID
  ORDER BY DATESTART DESC;

/* INSERT PLAYERS */
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Michael', 'Durham');
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Coleen', 'Billy');
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Jeff', 'Tawnie');
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Britannia', 'Makenna');
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Sandra', 'Fournier');
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Bryan', 'Robinson');
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Katie', 'Kemp');
INSERT INTO PLAYERS (FIRSTNAME, LASTNAME) VALUES ('Nathan', 'Dillon');

/* INSERT BOARDGAMES */
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Cosmic Encounter', 3, 5, 12, 60);
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Heroscape Master Set: Rise of the Valkyrie', 2, 4, 8, 90);
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Descent: Journeys in the Dark ', 2, 5, 18, 120);
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Mage Wars', 2, 2, 13, 90);
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Summoner Wars', 2, 4, 9, 30);
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Duel of Ages II', 2, 8, 18, 150);
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Caverna: The Cave Farmers', 2, 7, 12, 30);
INSERT INTO BOARDGAMES (NAME, MINIMUM_PLAYER_NUMBER, MAXIMUM_PLAYER_NUMBER, MINIMUM_AGE, AVERAGE_GAME_TIME) VALUES ('Le Havre', 1, 5, 18, 20);

/* INSERT EVENTS */
INSERT INTO EVENTS (NAME, DESCRIPTION, DATESTART) VALUES ('Game morning', 'Morning gaming', '14-06-26');
INSERT INTO EVENTS (NAME, DESCRIPTION, DATESTART) VALUES ('Game afternoon', 'Afternoon gaming', '14-07-5');
INSERT INTO EVENTS (NAME, DESCRIPTION, DATESTART) VALUES ('Game evening', 'Evening gaming', '14-11-13');
INSERT INTO EVENTS (NAME, DESCRIPTION, DATESTART) VALUES ('Game night', 'Night gaming', '15-05-23');
INSERT INTO EVENTS (NAME, DESCRIPTION, DATESTART) VALUES ('Game day', 'Day gaming', '15-06-2');

/* INSERT BOARDGAME_EVENT */
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (1, 1);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (3, 1);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (2, 2);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (4, 3);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (8, 4);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (7, 4);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (5, 5);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (6, 5);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (1, 5);
INSERT INTO BOARDGAME_EVENT (BOARDGAME_ID, EVENT_ID) VALUES (8, 3);

/* INSERT EVENT_PLAYER */
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (1, 1);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (1, 2);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (2, 3);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (3, 4);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (3, 5);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (4, 6);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (4, 7);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (4, 8);
INSERT INTO EVENT_PLAYER (EVENT_ID, PLAYER_ID) VALUES (5, 1);

COMMIT;