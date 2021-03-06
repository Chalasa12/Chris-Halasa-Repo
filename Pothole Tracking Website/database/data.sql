USE [Potholes]
GO
SET IDENTITY_INSERT [dbo].[Pothole] ON 

INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (255, N'Inspection Scheduled', 1, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-83.055987 AS Decimal(18, 6)), CAST(39.950963 AS Decimal(18, 6)), NULL, CAST(N'2018-04-20' AS Date))
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (256, N'Repaired', 5, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-82.961965 AS Decimal(18, 6)), CAST(39.953037 AS Decimal(18, 6)), CAST(N'2018-04-20' AS Date), CAST(N'2018-04-19' AS Date))
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (257, N'Inspected', 3, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-83.031319 AS Decimal(18, 6)), CAST(40.006088 AS Decimal(18, 6)), NULL, CAST(N'2018-04-20' AS Date))
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (258, N'Inspection Scheduled', 2, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-82.990446 AS Decimal(18, 6)), CAST(40.023042 AS Decimal(18, 6)), NULL, CAST(N'2018-04-23' AS Date))
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (259, N'Reported', 4, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-83.119164 AS Decimal(18, 6)), CAST(39.974485 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (260, N'Reported', 1, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-83.127371 AS Decimal(18, 6)), CAST(39.957106 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (261, N'Reported', 3, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-83.127371 AS Decimal(18, 6)), CAST(39.957106 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (262, N'Reported', 1, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-82.995143 AS Decimal(18, 6)), CAST(39.956132 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (263, N'Reported', 5, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-83.069771 AS Decimal(18, 6)), CAST(40.045257 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (264, N'Reported', 4, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-82.847244 AS Decimal(18, 6)), CAST(39.915785 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (265, N'Reported', 5, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-83.304548 AS Decimal(18, 6)), CAST(40.020363 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (266, N'Reported', 4, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-82.919756 AS Decimal(18, 6)), CAST(39.900841 AS Decimal(18, 6)), NULL, NULL)
INSERT [dbo].[Pothole] ([PotHole_ID], [Status], [Severity], [Date_Reported], [Picture], [User_ID], [Longitude], [Latitude], [Repair_Date], [Inspect_Date]) VALUES (267, N'Reported', 3, CAST(N'2018-04-19' AS Date), NULL, NULL, CAST(-82.968323 AS Decimal(18, 6)), CAST(40.126327 AS Decimal(18, 6)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Pothole] OFF
SET IDENTITY_INSERT [dbo].[Claims] ON 

INSERT [dbo].[Claims] ([User_ID], [Claims_ID], [Description], [Estimated_Cost], [Submission_Date], [Status], [PotHole_ID]) VALUES (1, 29, N'Front right tire flat and rim damaged', CAST(300 AS Decimal(18, 0)), CAST(N'2018-04-19' AS Date), N'Reported', 265)
INSERT [dbo].[Claims] ([User_ID], [Claims_ID], [Description], [Estimated_Cost], [Submission_Date], [Status], [PotHole_ID]) VALUES (1, 30, N'Front right tire flat and rim damaged', CAST(300 AS Decimal(18, 0)), CAST(N'2018-04-19' AS Date), N'Reported', 265)
INSERT [dbo].[Claims] ([User_ID], [Claims_ID], [Description], [Estimated_Cost], [Submission_Date], [Status], [PotHole_ID]) VALUES (1, 31, N'Front bumper and driver side tire damaged', CAST(400 AS Decimal(18, 0)), CAST(N'2018-04-19' AS Date), N'Reported', 266)
INSERT [dbo].[Claims] ([User_ID], [Claims_ID], [Description], [Estimated_Cost], [Submission_Date], [Status], [PotHole_ID]) VALUES (1, 32, N'Front bumper and driver side tire damaged', CAST(400 AS Decimal(18, 0)), CAST(N'2018-04-19' AS Date), N'Reported', 266)
INSERT [dbo].[Claims] ([User_ID], [Claims_ID], [Description], [Estimated_Cost], [Submission_Date], [Status], [PotHole_ID]) VALUES (1, 33, N'Damaged axle and rear tire', CAST(700 AS Decimal(18, 0)), CAST(N'2018-04-18' AS Date), N'Reported', 267)
INSERT [dbo].[Claims] ([User_ID], [Claims_ID], [Description], [Estimated_Cost], [Submission_Date], [Status], [PotHole_ID]) VALUES (1, 34, N'Damaged axle and rear tire', CAST(700 AS Decimal(18, 0)), CAST(N'2018-04-18' AS Date), N'Reported', 267)
SET IDENTITY_INSERT [dbo].[Claims] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([User_ID], [Username], [Password], [FirstName], [LastName], [Is_Employee], [Email]) VALUES (1, N'admin', N'password', N'chris', N'halasa', 1, N'abd@gmail.com')
INSERT [dbo].[Users] ([User_ID], [Username], [Password], [FirstName], [LastName], [Is_Employee], [Email]) VALUES (2, N'shankie', N'12345678', N'david', N'shankie', 0, N'abc@gmail.com')
INSERT [dbo].[Users] ([User_ID], [Username], [Password], [FirstName], [LastName], [Is_Employee], [Email]) VALUES (3, N'wefbza', N'12345678', N'zxc', N'zxc', 0, N'asd@gmail.com')
INSERT [dbo].[Users] ([User_ID], [Username], [Password], [FirstName], [LastName], [Is_Employee], [Email]) VALUES (4, N'23', N'12', N'we', N'e23', 0, N'asd@gmail.com')
INSERT [dbo].[Users] ([User_ID], [Username], [Password], [FirstName], [LastName], [Is_Employee], [Email]) VALUES (5, N'12', N'12', N'12', N'12', 0, N'asd@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
