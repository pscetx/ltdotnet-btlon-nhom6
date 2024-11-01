create database LTDOTNET_BTLON
drop database LTDOTNET_BTLON
use LTDOTNET_BTLON

CREATE TABLE Account (
    username VARCHAR(255) NOT NULL PRIMARY KEY,
    password VARCHAR(255) NOT NULL
);

CREATE TABLE League (
    id VARCHAR(255) PRIMARY KEY,
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Stadium (
    id VARCHAR(255) PRIMARY KEY,
    name VARCHAR(255) NOT NULL UNIQUE,
    capacity INT,
    location VARCHAR(255)
);

CREATE TABLE Team (
    id VARCHAR(255) PRIMARY KEY,
    full_name VARCHAR(255) NOT NULL,
    league_id VARCHAR(255) NOT NULL,
    goals_scored INT DEFAULT 0,
    goals_against INT DEFAULT 0,
    points INT DEFAULT 0,
    goal_difference INT DEFAULT 0,
    home_stadium_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (league_id) REFERENCES League(id),
    FOREIGN KEY (home_stadium_id) REFERENCES Stadium(id)
);

CREATE TABLE Player (
    id VARCHAR(255) PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    position VARCHAR(255),
    team_id VARCHAR(255) NOT NULL,
    nationality VARCHAR(255),
    age INT CHECK (age >= 0),
    goals INT DEFAULT 0,
    assists INT DEFAULT 0,
    yellow_cards INT DEFAULT 0,
    red_cards INT DEFAULT 0,
    minutes_played INT DEFAULT 0,
    FOREIGN KEY (team_id) REFERENCES Team(id)
);

CREATE TABLE Match (
    id VARCHAR(255) PRIMARY KEY,
	league_id VARCHAR(255) NOT NULL,
    home_team_id VARCHAR(255) NOT NULL,
    away_team_id VARCHAR(255) NOT NULL,
    home_team_score INT DEFAULT 0,
    away_team_score INT DEFAULT 0,
    match_date DATETIME NOT NULL,
    home_team_shots_attempted INT DEFAULT 0,
    away_team_shots_attempted INT DEFAULT 0,
    home_team_possession INT DEFAULT 0,
    away_team_possession INT DEFAULT 0,
    home_team_yellow_cards INT DEFAULT 0,
    away_team_yellow_cards INT DEFAULT 0,
    home_team_red_cards INT DEFAULT 0,
    away_team_red_cards INT DEFAULT 0,
	FOREIGN KEY (league_id) REFERENCES League(id),
    FOREIGN KEY (home_team_id) REFERENCES Team(id),
    FOREIGN KEY (away_team_id) REFERENCES Team(id),
    CONSTRAINT chk_different_teams CHECK (home_team_id <> away_team_id)
);

INSERT INTO Account (username, password) VALUES
('admin', '123'),
('user', 'password');

INSERT INTO League (id, name) VALUES 
('PL', 'Premier League'),
('LL', 'La Liga'),
('SA', 'Serie A'),
('BL', 'Bundesliga'),
('L1', 'Ligue 1');

INSERT INTO Stadium (id, name, capacity, location) VALUES 
('OT', 'Old Trafford', 75000, 'Manchester'),
('CN', 'Camp Nou', 99354, 'Barcelona'),
('SS', 'San Siro', 80018, 'Milan'),
('AF', 'Anfield', 54074, 'Liverpool'),
('AA', 'Allianz Arena', 75000, 'Munich'),
('PP', 'Parc des Princes', 47929, 'Paris');

INSERT INTO Team (id, full_name, league_id, goals_scored, goals_against, points, goal_difference, home_stadium_id) VALUES 
('MU', 'Manchester United', 'PL', 60, 35, 75, 25, 'OT'),
('BAR', 'FC Barcelona', 'LL', 78, 28, 85, 50, 'CN'),
('MIL', 'AC Milan', 'SA', 55, 40, 68, 15, 'SS'),
('LIV', 'Liverpool FC', 'PL', 70, 30, 80, 40, 'AF'),
('BAY', 'Bayern Munich', 'BL', 85, 25, 88, 60, 'AA'),
('PSG', 'Paris Saint-Germain', 'L1', 80, 20, 90, 60, 'PP'),
('RM', 'Real Madrid', 'LL', 77, 29, 83, 48, 'CN'),
('INT', 'Inter Milan', 'SA', 54, 41, 65, 13, 'SS');

INSERT INTO Player (id, name, position, team_id, nationality, age, goals, assists, yellow_cards, red_cards, minutes_played) VALUES 
('DDG', 'David De Gea', 'Goalkeeper', 'MU', 'Spanish', 32, 0, 0, 1, 0, 2900),
('LM', 'Lionel Messi', 'Forward', 'BAR', 'Argentinian', 36, 25, 10, 3, 0, 2600),
('ZI', 'Zlatan Ibrahimovic', 'Forward', 'MIL', 'Swedish', 41, 18, 5, 2, 1, 2200),
('MS', 'Mo Salah', 'Forward', 'LIV', 'Egyptian', 31, 23, 8, 1, 0, 2700),
('MN', 'Manuel Neuer', 'Goalkeeper', 'BAY', 'German', 37, 0, 0, 2, 0, 2800),
('KM', 'Kylian Mbappe', 'Forward', 'PSG', 'French', 25, 30, 7, 2, 1, 2500),
('KB', 'Karim Benzema', 'Forward', 'RM', 'French', 36, 22, 6, 4, 0, 2450),
('MR', 'Marcus Rashford', 'Forward', 'MU', 'English', 26, 15, 9, 2, 0, 2300),
('PDR', 'Pedri', 'Midfielder', 'BAR', 'Spanish', 21, 5, 12, 1, 0, 2400),
('JK', 'Joshua Kimmich', 'Midfielder', 'BAY', 'German', 29, 8, 15, 3, 0, 2750),
('CDK', 'Charles De Ketelaere', 'Forward', 'MIL', 'Belgian', 23, 10, 3, 0, 0, 2200),
('DV', 'Darwin Núñez', 'Forward', 'LIV', 'Uruguayan', 24, 12, 4, 1, 0, 2100);

INSERT INTO Match (id, league_id, home_team_id, away_team_id, home_team_score, away_team_score, match_date, home_team_shots_attempted, away_team_shots_attempted, home_team_possession, away_team_possession, home_team_yellow_cards, away_team_yellow_cards, home_team_red_cards, away_team_red_cards) VALUES 
('MU_LIV_1', 'PL', 'MU', 'LIV', 2, 2, '2024-10-15 15:00:00', 15, 10, 55, 45, 2, 3, 0, 0),
('BAR_RM_1', 'LL', 'BAR', 'RM', 3, 1, '2024-10-20 18:00:00', 20, 8, 60, 40, 1, 2, 0, 0),
('BAY_PSG_1', 'BL', 'BAY', 'PSG', 2, 3, '2024-10-22 20:45:00', 18, 12, 52, 48, 3, 1, 0, 1),
('MIL_MU_1', 'SA', 'MIL', 'MU', 1, 0, '2024-10-25 19:30:00', 10, 15, 47, 53, 2, 2, 1, 0),
('LIV_RM_1', 'PL', 'LIV', 'RM', 1, 2, '2024-11-02 15:00:00', 14, 16, 50, 50, 4, 2, 0, 0),
('BAY_MIL_1', 'BL', 'BAY', 'MIL', 4, 1, '2024-11-05 18:30:00', 25, 11, 65, 35, 1, 0, 0, 0),
('PSG_LIV_1', 'L1', 'PSG', 'LIV', 3, 1, '2024-11-10 17:00:00', 22, 9, 58, 42, 1, 3, 0, 0),
('BAR_MU_1', 'LL', 'BAR', 'MU', 2, 2, '2024-11-12 20:00:00', 22, 14, 57, 43, 2, 2, 0, 1);

SELECT * FROM League;
SELECT * FROM Stadium;
SELECT * FROM Team;
SELECT * FROM Player;
SELECT * FROM Match;

CREATE TRIGGER update_team_stats_after_match
ON Match
AFTER INSERT
AS
BEGIN
    DECLARE @home_team_id VARCHAR(255),
            @away_team_id VARCHAR(255),
            @home_team_score INT,
            @away_team_score INT,
            @home_team_points INT = 0,
            @away_team_points INT = 0;

    SELECT 
        @home_team_id = home_team_id,
        @away_team_id = away_team_id,
        @home_team_score = home_team_score,
        @away_team_score = away_team_score
    FROM INSERTED;

    IF @home_team_score > @away_team_score 
    BEGIN
        SET @home_team_points = 3;
        SET @away_team_points = 0;
    END
    ELSE IF @home_team_score < @away_team_score
    BEGIN
        SET @home_team_points = 0;
        SET @away_team_points = 3;
    END
    ELSE
    BEGIN
        SET @home_team_points = 1;
        SET @away_team_points = 1;
    END

    UPDATE Team
    SET 
        goals_scored = goals_scored + @home_team_score,
        goals_against = goals_against + @away_team_score,
        points = points + @home_team_points,
        goal_difference = goal_difference + (@home_team_score - @away_team_score)
    WHERE id = @home_team_id;

    UPDATE Team
    SET 
        goals_scored = goals_scored + @away_team_score,
        goals_against = goals_against + @home_team_score,
        points = points + @away_team_points,
        goal_difference = goal_difference + (@away_team_score - @home_team_score)
    WHERE id = @away_team_id;
END;

ALTER VIEW LeagueRanking AS
SELECT
	RANK() OVER (PARTITION BY league_id ORDER BY points DESC, goal_difference DESC, goals_scored DESC) AS rank,
    id AS team_id,
    full_name,
    points,
    goal_difference,
    goals_scored,
    goals_against,
	league_id
FROM 
    Team;

SELECT * FROM LeagueRanking WHERE league_id = 'LL';