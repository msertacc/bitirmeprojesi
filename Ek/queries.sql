USE [SSA]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0', N'Teacher', N'Teacher', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Student', N'Student', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7c79e685-2d01-4dc4-8af4-0b680f1a5a35', N'0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0001f27d-5c99-4786-9281-ec530b473690', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bc5cbb76-0b16-472d-8ab0-3453ece564dc', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa9d6070-cedf-44a4-9e06-95717c0873f7', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1aba6059-9ee5-4d99-9454-6f548498a7bd', N'2')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e55c86aa-41ae-4f87-9e72-e1d21806279c', N'2')
GO




SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([Id], [Name], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1, N'Matematik', N'Dell', CAST(N'2023-05-29T22:00:13.5547367' AS DateTime2), NULL, NULL, N'1')
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Exam] ON 
GO
INSERT [dbo].[Exam] ([Id], [ExamName], [ExamDescription], [ExamStartTime], [ExamEndTime], [CourseId], [IsEnded], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1, N'Matematik-1', N'Matematik sinavidir', CAST(N'2023-06-09T01:16:00.0000000' AS DateTime2), CAST(N'2023-06-09T02:00:00.0000000' AS DateTime2), 1, N'0', N'Dell', CAST(N'2023-05-29T22:21:04.2045586' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Exam] ([Id], [ExamName], [ExamDescription], [ExamStartTime], [ExamEndTime], [CourseId], [IsEnded], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (2, N'Matematik-1', N'Matematik sinavidir', CAST(N'2023-05-29T22:16:00.0000000' AS DateTime2), CAST(N'2023-06-07T05:16:00.0000000' AS DateTime2), 1, N'0', N'Dell', CAST(N'2023-05-29T22:23:03.8869408' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:11:00.8142287' AS DateTime2), N'0')
GO
INSERT [dbo].[Exam] ([Id], [ExamName], [ExamDescription], [ExamStartTime], [ExamEndTime], [CourseId], [IsEnded], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (3, N'Sertac-1', N'Sertac sinavi', CAST(N'2023-05-29T22:24:00.0000000' AS DateTime2), CAST(N'2023-05-29T23:24:00.0000000' AS DateTime2), 1, N'1', N'Dell', CAST(N'2023-05-29T22:24:12.4061298' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:10:51.5520450' AS DateTime2), N'0')
GO
SET IDENTITY_INSERT [dbo].[Exam] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ExamId], [Score], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1, N'Türkiyenin baþkenti neresidir?', 1, 20, N'Dell', CAST(N'2023-06-03T14:52:01.0796003' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:52.6278551' AS DateTime2), N'1')
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ExamId], [Score], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (2, N'hfgjhgj', 2, 54, N'Dell', CAST(N'2023-06-03T14:54:39.2099220' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:11:00.8402319' AS DateTime2), N'0')
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ExamId], [Score], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (3, N'ghghd', 2, 144, N'Dell', CAST(N'2023-06-03T14:55:24.6208199' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:11:00.9194906' AS DateTime2), N'0')
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ExamId], [Score], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (4, N'Ankarada deniz var mýdýr?', 1, 30, N'Dell', CAST(N'2023-06-03T14:59:51.0560768' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:00.5292497' AS DateTime2), N'1')
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ExamId], [Score], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (5, N'Üsküdar hangi ilimizdedir?', 1, 4, N'Dell', CAST(N'2023-06-03T15:07:55.6479439' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ExamId], [Score], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (6, N'Aþaðýdakilerden hangisi siyasetçi deðildir?', 1, 46, N'Dell', CAST(N'2023-06-03T15:12:33.2993715' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:10.2081601' AS DateTime2), N'1')
GO
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Choice] ON 
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1, N'Ýzmir', 1, 1, N'Dell', CAST(N'2023-06-03T14:52:03.5504843' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.7762166' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (2, N'Ankara', 0, 1, N'Dell', CAST(N'2023-06-03T14:52:03.5771889' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.8145582' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (3, N'Ýstanbul', 0, 1, N'Dell', CAST(N'2023-06-03T14:52:03.5779497' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.8150355' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (4, N'jkkkkkkk', 0, 2, N'Dell', CAST(N'2023-06-03T14:54:39.8973528' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:11:00.8929822' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (5, N'gggg', 1, 2, N'Dell', CAST(N'2023-06-03T14:54:39.9409960' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:11:00.9193466' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (6, N'kjkg', 1, 3, N'Dell', CAST(N'2023-06-03T14:55:24.8300353' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:11:00.9222676' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (7, N'kjgkg', 0, 3, N'Dell', CAST(N'2023-06-03T14:55:24.8304275' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-08T21:11:00.9226751' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (8, N'Deniz vardýr', 1, 4, N'Dell', CAST(N'2023-06-03T14:59:51.7219096' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:00.5324415' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (9, N'Deniz yoktur', 0, 4, N'Dell', CAST(N'2023-06-03T14:59:51.7504374' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:00.5327337' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (10, N'Ýkiside', 1, 4, N'Dell', CAST(N'2023-06-03T15:01:50.2470324' AS DateTime2), N'Dell', CAST(N'2023-06-03T15:02:11.8035418' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (11, N'Hiçbiri', 0, 4, N'Dell', CAST(N'2023-06-03T15:01:50.2472449' AS DateTime2), N'Dell', CAST(N'2023-06-03T15:02:11.8038216' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (12, N'hgf', 0, 4, N'Dell', CAST(N'2023-06-03T15:01:50.2474056' AS DateTime2), N'Dell', CAST(N'2023-06-03T15:02:11.8039582' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (13, N'2', 0, 4, N'Dell', CAST(N'2023-06-03T15:02:11.9338529' AS DateTime2), N'Dell', CAST(N'2023-06-03T15:02:27.8460099' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (14, N'3', 0, 4, N'Dell', CAST(N'2023-06-03T15:02:11.9342202' AS DateTime2), N'Dell', CAST(N'2023-06-03T15:02:27.8472241' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (15, N'hgf', 1, 4, N'Dell', CAST(N'2023-06-03T15:02:11.9344582' AS DateTime2), N'Dell', CAST(N'2023-06-03T15:02:27.8474800' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (16, N'Antalya', 0, 5, N'Dell', CAST(N'2023-06-03T15:07:55.9668232' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (17, N'Ýstanbul', 1, 5, N'Dell', CAST(N'2023-06-03T15:07:56.0050066' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (18, N'Cem Yýlmaz', 0, 6, N'Dell', CAST(N'2023-06-03T15:12:33.6577457' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:10.2122563' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (19, N'Recep Tayyip Erdoðan', 1, 6, N'Dell', CAST(N'2023-06-03T15:12:33.6879474' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:10.2127977' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (20, N'Kemal Kýlýçdaroðlu', 0, 6, N'Dell', CAST(N'2023-06-03T15:12:33.6888751' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:10.2130907' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (22, N'Ankara', 0, 5, N'Dell', CAST(N'2023-06-03T15:12:33.2993715' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (23, N'Adana', 0, 5, N'Dell', CAST(N'2023-06-03T15:12:33.2993715' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (24, N'Ýzmirname="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.9531391' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.0550539' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (25, N'Ankaraname="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.9804228' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.0790932' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (26, N'Ýstanbulname="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.9811937' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.0794593' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (27, N'vvv', 1, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.9814721' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.0795670' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (28, N'fdf', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.9817192' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.0796761' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (29, N'ff', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-07T13:58:35.9819023' AS DateTime2), N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.0797773' AS DateTime2), N'0')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1001, N'Ýzmirname="fname"name="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.2189171' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1002, N'Ankaraname="fname"name="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.2332246' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1003, N'Ýstanbulname="fname"name="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.2337677' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1004, N'vvvname="fname"', 1, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.2338958' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1005, N'fdfname="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.2340596' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1006, N'ffname="fname"', 0, 1, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:11:53.2341760' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1007, N'Deniz', 1, 4, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:00.5392592' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1008, N'Deniz', 0, 4, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:00.5395819' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1009, N'Cem', 0, 6, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:10.2298201' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1010, N'Recep', 1, 6, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:10.2301935' AS DateTime2), NULL, NULL, N'1')
GO
INSERT [dbo].[Choice] ([Id], [ChoiceExplanation], [IsTrue], [QuestionId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (1011, N'Kemal', 0, 6, N'DESKTOP-0IL4JB7$', CAST(N'2023-06-09T01:12:10.2303463' AS DateTime2), NULL, NULL, N'1')
GO
SET IDENTITY_INSERT [dbo].[Choice] OFF
GO
SET IDENTITY_INSERT [dbo].[ExamUser] ON 
GO
INSERT [dbo].[ExamUser] ([Id], [ExamId], [UserId], [InsertedUser], [InsertedDate], [UpdatedUser], [UpdatedDate], [IsActive]) VALUES (2, 1, N'bc5cbb76-0b16-472d-8ab0-3453ece564dc', N'test', CAST(N'2023-05-29T22:16:00.0000000' AS DateTime2), NULL, NULL, N'1')
GO
SET IDENTITY_INSERT [dbo].[ExamUser] OFF
GO
