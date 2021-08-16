package studentdatabaseapp;

import java.util.Scanner;

public class Student {
	
	private String 	firstName;
	private String  lastName;
	private int gradeYear;
	private String studentID;
	private String courses=	null;
	private int tuitionBalance=0;
	private static int costofCourse=1500;
	private static int id=1001;
	
	//Constructor:prompts to enter student's name and year
	
	public Student() {
		
		Scanner in=new Scanner(System.in);
		//System.out.println("*****************************************************************");
		//System.out.println("                     MASK EDUCATION CENTRE                       ");
		//System.out.println("*****************************************************************");
		
		System.out.println("\nEnter the student's first name: ");
		this.firstName=in.nextLine();
		
		System.out.println("Enter the student's last name: ");
		this.lastName=in.nextLine();
		
		System.out.println("1 - Freshman\n2 - Sophmore\n3 - Junior\n4 - Senior\nEnter the student's class level: ");
		this.gradeYear=in.nextInt();
		
		setStudentID();
		
		
	}
	
	//Genetrate an id
	
	private void setStudentID() {
		//Grade level + ID
		id++;
		this.studentID = gradeYear + "" + id;
		
	}
	
	//enroll in courses
	
	public void enroll() {
		//get inside a loop,user hits 0
	do {
		System.out.println("Enter the course to enroll(Cost of course:1500)(Q to quit): ");
		Scanner in=new Scanner(System.in);
		String course=in.nextLine();
		if(!course.equals("Q")) {
			courses = courses + "\n" + course;
			tuitionBalance = tuitionBalance + costofCourse;
		}
		else { break; }
		
	}while(1 != 0);
	}
	
	
	//view balance
	
	public void viewBalance() {
	
		System.out.println("Your balance is Rs."  + tuitionBalance);
		
	}
	
	//pay tution 
	
	public void payTuition() {
		viewBalance();
		System.out.println("Enter your payment: Rs."); 
		Scanner in=new Scanner(System.in);
		int payment=in.nextInt();
		tuitionBalance = tuitionBalance - payment;
		System.out.println("Thank you for your payment of Rs." + payment);
		viewBalance();
	}
	//show status
	
	public String toString() {
		
		System.out.println("\n********Student Details********\n");
		return "Name: " + firstName +  " " + lastName +
				"\nGrade level: " + gradeYear +
				"\nStudent ID: " + studentID +
				"\nCourses Enrolled:" + courses +
				"\nBalance: Rs." + tuitionBalance;
	
    }

}
