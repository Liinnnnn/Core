create database CinemaDB
GO
use CinemaDB
Go
GO
-- Bảng User (Người dùng)
create TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(50) NOT NULL,
    BirthDay DATE,
    Gender NVARCHAR(10),
    PhoneNumber VARCHAR(10),
    AvatarImg VARCHAR(255),
    Email VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(20) NOT NULL,
    Type NVARCHAR(10) -- Loại tài khoản (ví dụ: admin, customer)
);
GO

-- Bảng Cinema (Rạp chiếu phim)
CREATE TABLE Cinema (
    CinemaID INT PRIMARY KEY IDENTITY(1,1),
    CinemaName NVARCHAR(50) NOT NULL,
    Address NVARCHAR(100)
);
GO

-- Bảng Film (Phim)
CREATE TABLE Film (
    FilmID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Language NVARCHAR(50),
    Director NVARCHAR(50),
    Description  NVARCHAR(MAX),
	suatChieu nvarchar(50),
    Duration INT, -- Thời lượng phim (phút)
    Year INT, -- Năm sản xuất
	FilmImg nvarchar(255),
    BannerImg VARCHAR(255) -- Link đến hình ảnh banner của phim
);
GO
-- Bảng Showtime (Lịch chiếu)
CREATE TABLE Showtimes (
    ShowtimeID INT PRIMARY KEY IDENTITY(1,1),
    FilmID INT,
    CinemaID INT,
    ShowTimeDate DATETIME,
	ShowTimeHour varchar(20), -- Thời gian chiếu phim
    Capacity INT, -- Số ghế của phòng chiếu
    FOREIGN KEY (FilmID) REFERENCES Film(FilmID),
    FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
	on update cascade
);
GO

-- Bảng Ticket (Vé)
CREATE TABLE Ticket (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    SeatNumber VARCHAR(10) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    ShowtimeID INT,
	InvoiceID INT,
	FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID) 
	ON DELETE SET NULL,
    FOREIGN KEY (ShowtimeID) REFERENCES Showtimes(ShowtimeID)
	on update cascade
);
GO

-- Bảng Invoice (Hóa đơn)
CREATE TABLE Invoice (
    InvoiceID INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATETIME NOT NULL,
    PaymentAmount DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50), -- Phương thức thanh toán (ví dụ: thẻ, tiền mặt)
    TicketID INT,
    UserID INT,
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
	on update cascade
);
GO

GO
insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(001,N'Cám',N'Tiếng Việt',N'Trần Hữu Tấn',N'Câu chuyện phim là dị bản kinh dị đẫm máu lấy cảm hứng từ truyện cổ tích nổi tiếng Tấm Cám, nội dung chính của phim xoay quanh Cám - em gái cùng cha khác mẹ của Tấm đồng thời sẽ có nhiều nhân vật và chi tiết sáng tạo, gợi cảm giác vừa lạ vừa quen cho khán giả.',120,2024,'/img/film/tam.jpg','/img/film/banner0.png')
GO
GO
insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(002,N'Quỷ ám',N'Tiếng Anh-Phụ đề Việt',N'David Gordon Green',N'Phim lấy trung tâm là Ember (Aaron Eckhart), người đàn ông mất đi gia đình và đôi chân sau một tai nạn giao thông nghiêm trọng. Nhưng cũng kể từ sự kiện đau lòng ấy, anh sở hữu khả năng thâm nhập vào giấc mơ của người khác.'
,111,2023,'/img/film/quyam.jpg','/img/film/banner1.jpg')
GO
GO

insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(003,N'Transformer One',N'Tiếng Anh-Phụ đề Việt',N'Josh Cooley',N'Nội dung khai thác câu chuyện trên hành tinh Cybertron trước khi cuộc chiến giữa Decepticons và Autobots diễn ra. Lúc này Optimus Prime và Megatron mới chỉ là robot công nhân tên là Orion Pax (Chris Hemsworth lồng tiếng) và D16 (Brian Tyree Henry)'
,120,2024,'/img/film/robot.jpg','/img/film/banner2.jpg')
GO
GO

insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(004,N'Joker Điên có đôi',N'Tiếng Anh-Phụ đề Việt',N'Todd Phillips',N'Joker: Folie à Deux là phần nối tiếp câu chuyện về Arthur Fleck khi tạo ra một cuộc bạo loạn chưa từng có tại Gotham. Đặc biệt, Lady Gaga sẽ vào vai Harley Quinn, người tình nổi tiếng nhưng cũng không kém phần điên loạn của gã hề Joker.'
,120,2024,'/img/film/joker.jpg','/img/film/banner3.jpg')
GO
GO

insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(005,N'Venom',N'Tiếng Anh-Phụ đề Việt',N'Andy Serkis',N'Sau chuyến du lịch ngắn sang quê nhà của Spider-Man: No Way Home (2021), Eddie Brock (Tom Hardy) giờ đây cùng Venom “hành hiệp trượng nghĩa” và “nhai đầu” hết đám tội phạm trong thành phố. Tuy nhiên, đi đêm lắm cũng có ngày gặp ma, chính phủ Mỹ đã phát hiện ra sự tồn tại của con quái vật ngoài hành tinh này'
,114,2024,'/img/film/venom.png','/img/film/banner4.jpg')
GO
GO

insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(006,N'Latency',N'Tiếng Anh-Phụ đề Việt',N'James Croke',N'Khi Hana, một game thủ chuyên nghiệp với chứng sợ không gian rộng, nhận 1 thiết bị giúp cải thiện trò chơi của mình, liệu nó có đang xâm chiếm tâm trí cô. Liệu những điều kinh hãi ấy chỉ xuất hiện trong thế giới ảo.'
,115,2024,'/img/film/latency.png','/img/film/banner5.jpg')
GO
GO

insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(007,N'SHIN',N'Tiếng Anh-Phụ đề Việt',N'Shinobu Sasaki',N'Kỳ nghỉ hè bắt đầu, Shin cùng nhóm bạn thân trong "biệt đội Kasukabe" nhận được lời mời đến thăm công viên giải trí Đảo Khủng Long. Tình cờ thay, Shin cũng gặp gỡ chú khủng long nhỏ Nana và chú khủng long này gia nhập hội bạn của Shin. Tuy nhiên, sau đó bí mật đằng sau "thân thế" của Nana được tiết lộ và âm mưu độc ác xuất hiện khiến Shin và hội bạn phải ra tay cứu giúp.'
,118,2023,'/img/film/shin.png','/img/film/banner6.jpg')
GO
GO

insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(008,N'Đố anh bắt được em',N'Tiếng Hàn-Phụ đề Việt',N'RYOO Seung-wan',N'Phim kể về các điều tra viên lâu năm đã trở lại với nhiệm vụ bắt tội phạm đầy nguy hiểm. Đội điều tra tội phạm nguy hiểm của thám tử Seo Do-cheol (do Hwang Jung-min thủ vai), luôn dốc toàn lực, sẵn sàng hy sinh để hoàn thành nhiệm vụ. Khi nhận được vụ án điều tra về cái chết một giáo sư, họ phát hiện ra những mối liên kết phức tạp với các vụ án trước.'
,118,2023,'/img/film/da.png','/img/film/banner7.jpg')
GO
GO

insert into dbo.Film(FilmID,Name,Language,Director,Description,Duration,Year,FilmImg,BannerImg)
values(009,N'Avenger',N'Tiếng Anh-Phụ đề Việt',N'Anthony Russo',N'Sau những sự kiện tàn khốc của Avengers: Infinity War (2018), vũ trụ đang bị hủy hoại. Với sự trợ giúp của các đồng minh còn lại, Avengers đã lắp ráp một lần nữa để đảo ngược hành động của Thanos và khôi phục lại sự cân bằng cho vũ trụ.'
,181,2019,'/img/film/endGame.jpg','/img/film/banner8.jpg')
GO

GO


alter table dbo.Film add suatChieu nvarchar(100)

update Film 
set suatChieu=N'Showing' where FilmID=001 or FilmID=002 or FilmID=003

update Film 
set suatChieu=N'Preview' where FilmID=004 or FilmID=005 or FilmID=006

update Film 
set suatChieu=N'Special' where FilmID=007 or FilmID=008 or FilmID=009

GO
GO
INSERT INTO Showtimes (FilmID, ShowtimeDate, Capacity, ShowTimeHour)
SELECT 
    FilmID, 
    DATEADD(DAY, n, CAST(GETDATE() AS DATE)) AS ShowtimeDate, 
    100, 
    CONCAT(hour, ' ', FORMAT(DATEADD(DAY, n, CAST(GETDATE() AS DATETIME)), 'dd/MM')) AS ShowTimeHour
FROM Film
CROSS JOIN (VALUES ('15:00'), ('17:00'), ('20:00')) AS Hours(hour)  -- Các giờ chiếu
CROSS JOIN (SELECT TOP 7 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n FROM sys.objects) AS Days  -- 7 ngày tới
WHERE suatChieu = 'Showing'
  AND NOT EXISTS (
    SELECT 1 
    FROM Showtimes 
    WHERE Showtimes.FilmID = Film.FilmID 
      AND Showtimes.ShowtimeDate = DATEADD(DAY, n, CAST(GETDATE() AS DATE))
      AND Showtimes.ShowTimeHour = CONCAT(hour, ' ', FORMAT(DATEADD(DAY, n, CAST(GETDATE() AS DATETIME)), 'dd/MM'))
);
GO
GO

-- Chèn dữ liệu cho suatChieu = 'Preview'
INSERT INTO Showtimes (FilmID, ShowtimeDate, Capacity, ShowTimeHour)
SELECT 
    FilmID, 
    DATEADD(DAY, n, CAST(GETDATE() AS DATE)) AS ShowtimeDate, 
    100, 
    FORMAT(DATEADD(DAY, n, CAST(GETDATE() AS DATETIME)), '12:00 dd/MM') AS ShowTimeHour
FROM Film
CROSS JOIN (SELECT TOP 7 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n FROM sys.objects) AS Days  -- 7 ngày tới
WHERE suatChieu = 'Preview'
  AND DATEPART(WEEKDAY, DATEADD(DAY, n, CAST(GETDATE() AS DATE))) IN (2, 4, 6)  -- Thứ 2, 4, 6
  AND NOT EXISTS (
    SELECT 1 
    FROM Showtimes
    WHERE Showtimes.FilmID = Film.FilmID 
      AND Showtimes.ShowtimeDate = DATEADD(DAY, n, CAST(GETDATE() AS DATE))
      AND Showtimes.ShowTimeHour = FORMAT(DATEADD(DAY, n, CAST(GETDATE() AS DATETIME)), '12:00 dd/MM')
);
GO
GO

-- Chèn dữ liệu cho suatChieu = 'Special'
INSERT INTO Showtimes (FilmID, ShowtimeDate, Capacity, ShowTimeHour)
SELECT 
    FilmID, 
    DATEADD(DAY, n, CAST(GETDATE() AS DATE)) AS ShowtimeDate, 
    100, 
    FORMAT(DATEADD(DAY, n, CAST(GETDATE() AS DATETIME)), '21:00 dd/MM') AS ShowTimeHour
FROM Film
CROSS JOIN (SELECT TOP 7 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n FROM sys.objects) AS Days  -- 7 ngày tới
WHERE suatChieu = 'Special'
  AND DATEPART(WEEKDAY, DATEADD(DAY, n, CAST(GETDATE() AS DATE))) IN (7, 1)  -- Thứ 7, Chủ nhật
  AND NOT EXISTS (
    SELECT 1 
    FROM Showtimes 
    WHERE Showtimes.FilmID = Film.FilmID 
      AND Showtimes.ShowtimeDate = DATEADD(DAY, n, CAST(GETDATE() AS DATE))
      AND Showtimes.ShowTimeHour = FORMAT(DATEADD(DAY, n, CAST(GETDATE() AS DATETIME)), '21:00 dd/MM')
);
GO

INSERT INTO [CInemaDB].[dbo].[User]  (FullName,[Email], [Password], [Type])VALUES  ( 'Admin','admin', 'admin', 'Admin');