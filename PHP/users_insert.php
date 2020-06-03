<?php
	$userName = $_POST["userName"];
	$password = $_POST["password"];
	$password = md5($password);

	$runOnce = 0;
	$flag = 0;

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	$sql = "insert into Users(userName, userPassword, level) ";
	$sql .= "value('$userName', '$password', 1)";

	if($runOnce == 0) {
		mysqli_query($con, $sql);
		$runOnce = 1;
	}

	$sql2 = "select userID from Users ";
	$sql2 .= "where userName = '$userName'";

	$result = mysqli_query($con, $sql2);
	$row = mysqli_fetch_array($result);

	$userID = (int)$row["userID"];
	echo $userID;

	$sql3 = "insert into Items(userID, potionItem, shieldItem) ";
	$sql3 .= "value($userID, 10, 10);";

	$sql4 = "insert into Marbles(userID, lv1, lv2, lv3) ";
	$sql4 .= "value($userID, 15, 15, 15);";

	$sql5 = "insert INTO Monsters(userID, mon1_1, mon1_2, mon1_3, mon2_1, mon2_2, mon2_3, mon3_1, mon3_2, mon3_3, bonus_mon1, bonus_mon2, bonus_mon3) value($userID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);";

	if($flag == 0) {
		mysqli_query($con, $sql3);
		mysqli_query($con, $sql4);
		mysqli_query($con, $sql5);
		$flag = 1;
	}
	mysqli_close($con);
?>