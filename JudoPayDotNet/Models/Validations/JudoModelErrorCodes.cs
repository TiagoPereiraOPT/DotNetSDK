﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudoPayDotNet.Models.Validations
{
    public enum JudoModelErrorCode
    {
        JudoId_Not_Supplied = 0,
        JudoId_Not_Valid = 2,

        Amount_Greater_Than_0 = 4,
        Amount_Not_Valid = 5,
        Amount_Two_Decimal_Places = 6,
        Amount_Between_0_And_5000 = 7,
        
        Partner_Service_Fee_Not_Valid = 8,
        Partner_Service_Fee_Between_0_And_5000 = 9,
        
        Consumer_Reference_Not_Supplied = 10,
        Consumer_Reference_Length = 12,

        Payment_Reference_Not_Supplied = 15,
        Payment_Reference_Length = 19,

        Currency_Required = 24,
        Currency_Length = 25,
        Currency_Not_Supported = 26,
        
        Device_Category_Unknown = 27,
        
        Card_Number_Not_Supplied = 28,
        
        Test_Cards_Only_In_Sandbox = 29,
        
        Card_Number_Invalid = 30,
        
        Three_Digit_CV2_Not_Supplied = 31,
        
        Four_Digit_CV2_Not_Supplied = 32,
        
        CV2_Not_Valid = 33,

        Start_Date_Or_Issue_Number_Must_Be_Supplied = 35,
        Start_Date_Not_Supplied = 36,
        Start_Date_Wrong_Length = 37,
        Start_Date_Not_Valid = 38,
        Start_Date_Not_Valid_Format = 39,
        Start_Date_Too_Far_In_Past = 40,
        Start_Date_Month_Outside_Expected_Range = 41,
        
        Issue_Number_Outside_Expected_Range = 42,
        
        Expiry_Date_Not_Supplied = 43,
        Expiry_Date_Wrong_Length = 44,
        Expiry_Date_Not_Valid = 45,
        Expiry_Date_In_Past = 46,
        Expiry_Date_Too_Far_In_Future = 47,
        Expiry_Date_Month_Outside_Expected_Range = 48,
        
        Postcode_Not_Valid = 49,
        Postcode_Not_Supplied = 50,
        Postcode_Is_Invalid = 51,
        
        Card_Token_Not_Supplied = 52,
        Card_Token_Original_Transaction_Failed = 53,
        
        ThreeDSecure_PaRes_Not_Supplied = 54,
        
        ReceiptId_Not_Supplied = 55,
        ReceiptId_Is_Invalid = 56,
        
        Transaction_Type_In_Url_Invalid = 57,
        
        Partner_Application_Reference_Not_Supplied = 58,
        Partner_Application_Reference_Not_Supplied_1 = 59,
        
        Type_Of_Company_Not_Supplied = 60,
        Type_Of_Company_Unknown = 61,
        
        Principle_Not_Supplied = 62,
        Principle_Salutation_Unknown = 63,
        Principle_First_Name_Not_Supplied = 64,
        Principle_First_Name_Length = 65,
        Principle_First_Name_Not_Supplied_1 = 66,
        Principle_Last_Name_Not_Supplied = 67,
        Principle_Last_Name_Length = 68,
        Principle_Last_Name_Not_Supplied_1 = 69,
        Principle_Email_Or_Mobile_Not_Supplied = 70,
        Principle_Email_Address_Not_supplied = 71,
        Principle_Email_Address_Length = 72,
        Principle_Email_Address_Not_Valid = 73,
        Principle_Email_Address_Domain_Not_Valid = 74,
        Principle_Mobile_Or_Email_Not_Supplied = 75,
        Principle_Mobile_Number_Not_Valid = 76,
        Principle_Mobile_Number_Not_Valid_1 = 77,
        Principle_Mobile_Number_Length = 78,
        Principle_Home_Phone_Not_Valid = 79,
        Principle_Date_Of_Birth_Not_Supplied = 80,
        Principle_Date_Of_Birth_Not_Valid = 81,
        Principle_Date_Of_Birth_Age = 82,
        
        Location_Trading_Name_Not_Supplied = 83,
        Location_Partner_Reference_Not_Supplied = 84,
        Location_Partner_Reference_Not_Supplied_1 = 85,
        Location_Partner_Reference_Length = 86,
        
        First_Name_Not_supplied = 87,
        First_Name_Length = 88,
        
        Last_Name_Not_Supplied = 89,
        Last_Name_Length = 90,
        
        Email_Address_Not_Supplied = 91,
        Email_Address_Length = 92,
        Email_Address_Not_Valid = 93,
        Email_Address_Domain_Not_Valid = 94,
        
        Schedule_Start_Date_Not_Supplied = 95,
        Schedule_Start_Date_Format_Not_Valid = 96,
        Schedule_End_Date_Not_Supplied = 97,
        Schedule_End_Date_Format_Not_Valid = 98,
        Schedule_End_Date_Must_Be_Greater_Than_Start_Date = 99,
        Schedule_Repeat_Not_Supplied = 100,
        Schedule_Repeat_Must_Be_Greater_Than_1 = 101,
        Schedule_Interval_Not_Valid = 102,
        Schedule_Interval_Must_Be_Minimum_5 = 103,
        
        ItemsPerPage_Not_Supplied = 104,
        ItemsPerPage_Out_Of_Range = 105,
        
        PageNumber_Not_Supplied = 106,
        PageNumber_Out_Of_Range = 107,
        
        Legal_Name_Not_Supplied = 108,
        
        Company_Number_Not_Supplied = 109,
        Company_Number_Wrong_Length = 110,
        
        Current_Address_Not_Supplied = 111,
        
        Building_Number_Or_Name_Not_Supplied = 112,
        Building_Number_Or_Name_Length = 113,
        
        Address_Line1_Not_Supplied = 114,
        Address_Line1_Length = 115,
        
        SortCode_Not_Supplied = 116,
        SortCode_Not_Valid = 117,
        
        Account_Number_Not_Supplied = 118,
        Account_number_Not_Valid = 119,
        
        Location_Turnover_Greater_Than_0 = 120,
        
        Average_Transaction_Value_Not_Supplied = 121,
        Average_Transaction_Value_Greater_Than_0 = 122,
        Average_Transaction_Value_Greater_Than_Turnover = 123,
        
        MccCode_Not_Supplied = 124,
        MccCode_Unknown = 125,

        Generic_Is_Invalid = 200,
        Generic_Html_Invalid = 201
    }
}
