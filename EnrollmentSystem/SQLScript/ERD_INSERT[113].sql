


			--INSERTS--

USE ERD;

	--STUDENTS--
		INSERT INTO student ( student_id, First_Name, Last_Name, Address ) VALUES ( 101, 'John', 'Simps', 'New York')
		INSERT INTO student ( student_id, First_Name, Last_Name, Address ) VALUES ( 102 , 'Mary', 'Belle', 'Las Vegas')
		INSERT INTO student ( student_id, First_Name, Last_Name, Address ) VALUES ( 103, 'Joanna', 'Keys', 'Los angeles')
		INSERT INTO student ( student_id, First_Name, Last_Name, Address ) VALUES ( 104, 'Mark', 'Sewer', 'Alabama')
		INSERT INTO student ( student_id, First_Name, Last_Name, Address ) VALUES ( 105, 'Ken', 'Maws', 'Canada')
		INSERT INTO student ( student_id, First_Name, Last_Name, Address ) VALUES ( 106, 'Lea', 'Reece', 'California')

	--PROFESSOR--
		INSERT INTO professor ( professor_id, First_Name, Last_Name, Address ) VALUES ( 501, 'Bruce', 'Jones', 'Canada')
		INSERT INTO professor ( professor_id, First_Name, Last_Name, Address ) VALUES ( 502, 'Irene', 'Lass', 'Detroit')
		INSERT INTO professor ( professor_id, First_Name, Last_Name, Address ) VALUES ( 503, 'Samantha', 'Holmes', 'Ohio')
	
	--COURSE--
		INSERT INTO course (  course_id, Name, Description ) VALUES ( 5001, 'BSIT', 'BACHELOR OF SCIENCE IN INFORMATION TECHNOLOGY')
		INSERT INTO course (  course_id, Name, Description ) VALUES ( 6001, 'BSHRM', 'BACHELOR OF SCIENCE IN HOTEL AND RESTAURANT MANAGEMENT')
		INSERT INTO course (  course_id, Name, Description ) VALUES ( 7001, 'BSBBA', 'BACHELOR OF SCIENCE IN BUSINESS ADMINISTRATION')

	
	--ClassSchedule

		INSERT INTO	ClassSchedule ( class_schedule_id, professor_id, course_id, Room, from_time, to_time, days )
		VALUES
		(10001, 501, 5001, 'OAK', '07:00', '12:00', 'MWF')


		INSERT INTO	ClassSchedule ( class_schedule_id, professor_id, course_id, Room, from_time, to_time, days )
		VALUES
		(10002, 501, 5001, 'ACACIA', '12:00', '17:00', 'TTH')

		INSERT INTO	ClassSchedule ( class_schedule_id, professor_id, course_id, Room, from_time, to_time, days )
		VALUES
		(20001, 502, 6001, 'NARRA', '07:00', '12:00', 'MWF')

		INSERT INTO	ClassSchedule ( class_schedule_id, professor_id, course_id, Room, from_time, to_time, days )
		VALUES
		(20002, 502, 6001, 'NARRA', '12:00', '17:00', 'TTH')

		INSERT INTO	ClassSchedule ( class_schedule_id, professor_id, course_id, Room, from_time, to_time, days )
		VALUES
		(30001, 503, 7001, 'ACACIA', '07:00', '12:00', 'MWF')

		INSERT INTO	ClassSchedule ( class_schedule_id, professor_id, course_id, Room, from_time, to_time, days )
		VALUES
		(30002, 503, 7001, 'OAK', '12:00', '17:00', 'TTH')

		
	--StudentCourse

		INSERT INTO StudentCourse ( studentcourse_id, student_id, course_id, class_schedule_id, enrollment_date, units )
		VALUES
		(7001,	101,	5001,	10002,	'2022/10/10 08:31:53',	20)

		INSERT INTO StudentCourse ( studentcourse_id, student_id, course_id, class_schedule_id, enrollment_date, units )
		VALUES
		(7002,	102,	7001,	30002,	'2022/10/15 09:35:13',	23)


		INSERT INTO StudentCourse ( studentcourse_id, student_id, course_id, class_schedule_id, enrollment_date, units )
		VALUES
		(7003,	103,	5001,	10001,	'2022/10/14 12:11:25',	20)

		INSERT INTO StudentCourse ( studentcourse_id, student_id, course_id, class_schedule_id, enrollment_date, units )
		VALUES
		(7004,	104,	6001,	20002,	'2022/10/14 09:41:55',	28)

		INSERT INTO StudentCourse ( studentcourse_id, student_id, course_id, class_schedule_id, enrollment_date, units )
		VALUES
		(7005,	105,7001,	30001,	'2022/10/11 11:31:12',	23)

		INSERT INTO StudentCourse ( studentcourse_id, student_id, course_id, class_schedule_id, enrollment_date, units )
		VALUES
		(7006,	106,	6001,	20001,	'2022/10/13 10:21:55',	28)


