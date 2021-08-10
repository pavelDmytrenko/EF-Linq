-- add users
insert into Users (Name)
select 'Tom'
insert into Users(Name)
select 'Sam'

-- add photos
insert into Photos(Context, CreatedDate, UserId)
select 'meeting', '8.2.2021', 1
insert into Photos(Context, CreatedDate, UserId)
select 'daily', '8.2.2021', 1
insert into Photos(Context, CreatedDate, UserId)
select 'dogs', '8.2.2021', 2

-- add likes
insert into Likes(CreatedDate, PhotoId)
select  '8.2.2021', 1
insert into Likes(CreatedDate, PhotoId)
select  '8.2.2021', 1
insert into Likes(CreatedDate, PhotoId)
select  '8.2.2021', 2