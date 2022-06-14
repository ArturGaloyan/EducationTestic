var langStore = {
	debug: false,
	state: {
		lang: "am",
		langs: {
			"en": {
				//Menu
				"logout": "Logout",        
				"home": "Home",           
				"student": "Student",     
				"teacher": "Teacher",
				"director": "Director",
				"testHistory": "Test History",
				"joinTest": "Join Test",
				"selectTest": "Select Test",
				"myClass": "My Class",
				//Teacher signupLogin
				"teacherLogin": "Login",
				"teacherSignup": "Registration",
				"email": "Email",
				"password": "Password",
				"login": "Login",
				"goToRegister": "Signup",
				"goToLogin": "Login",
				"name": "Name",
				"surname": "Surname",
				"licenseKey": "License Key",
				"submit": "Signup",
				//Teacher selectEdu
				"selectEducations": "Select Education",
				"selectParagraph": "Select Paragraph",
				"new": "New",
				"start": "Start",
				"browse": "Browse",
				"class": "Class",
				//Teacher newEdu
				"teacherName": "Teacher Name",
				"teacherNewEducation": "New Test",
				"selectClass": "Select Class",
				"selectItem": "Select Subject",
				"paragraphName": "Test name",
				"question": "Question",
				"true": "True",
				"selectTimer": "Select Timer",
				"selectPoint": "Select Point",
				"add": "Add",
				"save": "Save",
				"excelQuestion": "%letter% - Write a question in the column. for example. 10 + 10 =?", 
				"excelQuestionInstruction": "Instruction", 
				"excelAnswer": "%letter% - Write a question in the column. %ansNo%. for example. = %ansVal%",
				"excelTrueAnswer": "%letter% - Write an true answer in the column. %trueAns%. for example. = %ansVal%",
				"excelPoint": "%letter% - Write an point in the column. %point%. for example. %pointVal%. point",
				"excelTimer": "%letter% - Write an timer in the column. %minut%. for example. %minutVal%. minut",
				"addFromExcel": "Add From Excel",
				//Teacher editEdu
				"teacherEditEducation": "Edit Test",
				//Teacher Edu
				"selectGroup": "Select Group",
				"group": "Group",
				"questionNumber": "Question Number",
				"seeTestResults": "See Test Results",
				//Teacher History
				"selectSubject": "Select Subject",
				"filter": "Filter",
				"testingDate": "Testing Date",
				"paragraph": "Test name",
				"description": "Description",
				"see": "See",
				"noResults": "No Results",
				"selectClassAndSubject": "Select Class And Subject",
				//Teacher Finish
				"testingResult": "Testing Result",
				"date": "Date",
				"summary": "Summary",
				"points": "Points",
				"false": "False",
				"none": "None",
				"assessment": "Assessment",
				"detailedAnswers": "Detailed Answers",
				"questions": "Questions",
				"answers": "Answers",
				"isTrue": "Is True",
				"times": "Times",
				"notFoundTesting": "Test with id %testingID% not found or not belongs to you!",

				//Teacher My Class
				"classTeacherSubject": "Select Teacher for Subject",

				//Student signupLogin Namak
				"pleaseFillInAllTheFields": "Please fill in all the fields", // -
				"thePasswordIsShort": "The password is short",
				"can'tBeTheSame": "First name and last name can not be the same",
				"busyEmail": "This Email is already busy",
				"busyPassword": "This password is already busy",
				"passwordMustContain": "Password must contain 1 uppercase letter and at least 1 of these characters (! @ # $% ^ & *)",
				"wrongEmail": "Email is incorrect",
				"signupSuccess": "Signup Success. You can log in.",
				
				//Student signupLogin
				"studentLogin": "Login",
				"studentSignup": "Registration",
				"fatherName": "Father Name",
				"wrongLogin": "Wrong Login",
				"wrongPassword": "Wrong Password",
				"loginExists": "Login Exists",
				//Student edu
				"enterPassword": "Enter Password",
				"ok": "Ok",
				"notLoggedIn": "You are not logged In",
				"waitUntilStart": "Wait until test start",
				//Student finish
				"youHaveNoResult": "You Have No Result",
				"maxPoints": "Max Points",
				//Director signupLogin Namak
				"wrongLicense": "There is no such License",

				//Director signupLogin
				"directorLogin": "Login",
				"directorSignup": "Registration",
				/*"": "Please fill in all the fields", // -*/
				//Director testEdu
				"timer": "Timer",
				"point": "Point",
				"testEducation": "Test Education",
				//Director School Classes
				"schoolClasses": "School Classes",
				"add": "Add",
				"change": "Cange",
				"delete": "Delete",
				"filter": "Filter",
				"selectTeacher": "Select Teacher",
				"classDeleteConfirm": "Are you sure to delete %classNumber% %classGroup% class?",
				"addClass": "Add Class",
				"editClass": "Edit Class",
				"close": "Close",
				"update": "Update",
			},
			"am": {
				//Menu
				"logout": "Դուրս գալ", //+
				"home": "Գլխավոր", //+
				"student": "Ուսանող", //+
				"teacher": "Ուսուցիչ", //+
				"director": "Տնօրեն", //+
				"testHistory": "Թեստի պատմություն", //+
				"joinTest": "Միանալ թեստին", //+
				"selectTest": "Ընտրել թեստը", //+
				"myClass": "Իմ Դասարանը", //+
				//Teacher signupLogin
				"teacherLogin": "Մուտք", //+
				"teacherSignup": "Գրանցում", //+
				"email": "Էլեկտրոնային փոստ", //+
				"password": "Գաղտնաբառ", //+
				"login": "Մտնել", //+ ագիր
				"goToRegister": "Գրանցվել", //+
				"goToLogin": "Մտնել", //+
				"name": "Անուն", //+
				"surname": "Ազգանուն", //+
				"licenseKey": "Լիցենզիայի համար", //+
				"submit": "Գրանցվել", //+ Ներկայացնել
				//Teacher selectEdu
				"selectEducations": "Ընտրել Ստուգողական", //+
				"selectParagraph": "Ընտրել Թեման", //+
				"new": "Նոր", // +
				"start": "Սկսել", //+
				"browse": "Նայել", //+
				"class": "Դասարան", //+
				//Teacher newEdu
				"teacherName": "Ուսուցչի անուն", //+
				"teacherNewEducation": "Նոր ստուգողական", //+
				"selectClass": "Ընտրել Դասարանը", //+
				"selectItem": "Ընտրել Առարկան", //+
				"paragraphName": "Թեմա", //+
				"question": "Հարց", //+
				"true": "Ճիշտ պատասխան", //+
				"selectTimer": "Ընտրել Ժամանակը (Րոպե)", //+
				"selectPoint": "Ընտրել միավորը", //+
				"add": "Ավելացնել", //+
				"save": "Պահպանել", //+
				"excelQuestion": "A - սյունակում գրել հարց. օրինակ. 10 + 10 = ?", //+
				"excelAnswer": "%letter% - սյունակում գրել պատասխանը %ansNo%. օրինակ. = %ansVal%", //+
				"excelAnswerInstruction": "Լրացնելու կարգը", //+
				"excelTrueAnswer": "%letter% - սյունակում գրել Ճիշտ պատասխանը %trueAns%. օրինակ. = %ansVal%", //+
				"excelPoint": "%letter% - սյունակում գրել միավորը %point%. օրինակ. %pointVal%. միավոր", //+
				"excelTimer": "%letter% - սյունակում գրել ժամանակը %minut%. օրինակ. %minutVal%. րոպե", //+
				"addFromExcel": "Ընտրել Excel-ից ", //+
				//Teacher Edu
				"selectGroup": "Ընտրել Խումբը", //+
				"group": "Խումբ", //+
				"questionNumber": "Հարց համար", //+
				"seeTestResults": "Ստուգողականի արդյունքները", //+
				//Teacher History
				"selectSubject": "Ընտրել Առարկան", //+
				"filter": "Որոնել", //+
				"testingDate": "Ամսաթիվ", //+  Ստուգողականի
				"paragraph": "Թեմա", //+
				"description": "Նկարագրություն", //+
				"see": "Նայել", //+
				"noResults": "Արդյունքներ չկան", //+ 
				"selectClassAndSubject": "Ընտրել Դասարան և Առարկա", //+
				//Teacher Finish
				"testingResult": "Ստուգողականի Արդյունքներ", //+
				"date": "Ամսաթիվ", //+
				"summary": "Արդյունք", //+
				"points": "Միավորներ", //+
				"false": "Սխալ", //+
				"none": "Չկա", //+
				"assessment": "Գնահատական", //+
				"detailedAnswers": "Մանրամասներ", //+
				"questions": "Հարցեր", //+
				"answers": "Պատասխաններ", //+
				"isTrue": "Ճիշտ է արդյոք", //+
				"times": "Ժամանակ", //+
				"notFoundTesting": "%testingID% համարով թեստ չի գտնվել!", //+

				//Teacher My Class
				"classTeacherSubject": "Ընտրեք Ուսուցիչ առարկայի համար", //+

				//Student signupLogin Namak
				"pleaseFillInAllTheFields": "Խնդրում ենք լրացնել բոլոր դաշտերը", //+
				"thePasswordIsShort": "Ծածկագիրը կարճ է", //+
				"can'tBeTheSame": "Անունը և ազգանունը չեն կարող նույնը լինել", //+
				"busyEmail": "Այս Email-ը արդեն զբաղված է", //+
				"busyPassword": "Այս գաղտնաբառը արդեն զբաղված է", //+
				"passwordMustContain": "Գաղտնաբառը պետք է պարունակի 1 մեծատառ և տվյալ սիմվոլներից գոնե 1 - ը(!@#$%^&*)", //+
				"wrongEmail": "Email-ը սխալ է", //+
				"signupSuccess": "Գրանցումը հաջողությամբ կատարվել է: Դուք կարող եք մուտք գործել", //+



				//Student signupLogin
				"studentLogin": "Մուտք", //+
				"studentSignup": "Գրանցում ", //+
				"fatherName": "Հայրանուն", //+
				"wrongLogin": "Մութքագիրը սխալ է", //+

				"wrongPassword": "Գաղտնաբառը սխալ է", //+
				"loginExists": "Մութքագիրը արդեն զբաղված է", //+
				//Student edu
				"enterPassword": "Մուտքագրեք գաղտնաբառը", //+
				"ok": "Հաստատել", //+
				"notLoggedIn": "Դուք մուտք չեք գործել", //+
				"waitUntilStart": "Սպասեք մինչև թեստը սկսվի", //+
				//Student finish
				"youHaveNoResult": "Դուք չեք մասնակցել թեստին կամ արդյունքը չի պահպանվել", //+
				"maxPoints": "Առավելագույն միավորներ", //+
				//Director signupLogin Namak
				"wrongLicense": "Այդպիսի Լիցենզիա Չկա", //+

				//Director signupLogin
				"directorLogin": "Մուտք", //+
				"directorSignup": "Գրանցում", //+
				//Director testEdu
				"timer": "Ժամանակ", //+
				"point": "Միավոր", //+
				"testEducation": "Ստուգոքսական տեստ", //+
				//Director School Classes
				"schoolClasses": "Դպրոցի դասարանները", //+
				"add": "Ավելացնել", //+
				"change": "Փոփոխել", //+
				"delete": "Ջնջել", //+
				"filter": "Որոնել", //+
				"selectTeacher": "Ընտրել Ուսուցիչ", //+
				"classDeleteConfirm": "Դուք վստա՞հ եք, որ ուզում եք ջնջել %classNumber% %classGroup% դասարանը։", //+
				"addClass": "Ավելացնել դասարան",  //+
				"editClass": "Խմբագրել",  //+
				"close": "Փակել ",  //+
				"update": "Թարմացնել",  //+
			},
			"ru": {
				//Menu
				"logout": "Выйти", //+
				"home": "Главная", // ?
				"student": "Ученик", //+
				"teacher": "Учитель", //+
				"director": "Директор", //+
				"testHistory": "История тестов", //+ испытаний
				"joinTest": "Присоединиться к тесту", //+
				"selectTest": "Выбрать тест", // +
				"myClass": "Мои Класс", //+
				//Teacher signupLogin
				"teacherLogin": "Вход", //+
				"teacherSignup": "Регистрация", //+
				"email": "Эл. почта", //+
				"password": "Пароль", //+
				"login": "Войти", //+
				"goToRegister": "Зарегисрироваться", //+
				"goToLogin": "Войти", // Авторизоваться  ?+
				"name": "Имя", //+
				"surname": "Фамилия", //+
				"licenseKey": "Лицензионный ключ", //+
				"submit": "Зарегистрироваться", //+ Утверждать 
				//Teacher selectEdu
				"selectEducations": "Выбирать урок", //+
				"selectParagraph": "Выбирать тему", //+
				"new": "Новый", //+
				"start": "Начать", //+
				"browse": "Просмотр", //+ Просматривать
				"class": "Класс", //+
				//Teacher newEdu
				"teacherName": "Имя Преподавателья", //+
				"teacherNewEducation": "Новый тест", //+
				"selectClass": "Выберите класс", //+
				"selectItem": "Выбрать предмет", //+
				"paragraphName": "Название темы", //+
				"question": "Вопрос", //+
				"true": "Правильный ответ", //+
				"selectTimer": "Выберите время", //+
				"selectPoint": "Выберите балл", //+
				"add": "Добавить", //+
				"save": "Сохранить", //+
				"excelQuestion": "А - колонка. написать вопрос. например. 10 + 10 = ?", //+
				"excelQuestionInstruction": "Инструкция", //+
				"excelAnswer": "%letter% - колонка. написать ответ  %ansNo%. например. = %ansVal%", //+
				"excelTrueAnswer": "%letter% -  колонка. написать правильныи ответ %trueAns%. например. = %ansVal%", //+
				"excelPoint": "%letter% - колонка. написать балл %point%. например. %pointVal%. баллов", //+
				"excelTimer": "%letter% - колонка. написать время %minut%. например. %minutVal%. минута", //+
				"addFromExcel": "Выбрать фаил из Excel ", //+
				//Teacher Edu
				"selectGroup": "Выберите группу", //+
				"group": "Группа", //+
				"questionNumber": "Вопрос номер",
				"seeTestResults": "Результаты теста", //+
				//Teacher History
				"selectSubject": "Выберите предмет", // предмет  +  ?
				"filter": "Фильтр", //+
				"testingDate": "Дата тестирования", //+
				"paragraph": "Тема", //  Предмет  +
				"description": "Описание", //+
				"see": "Просмотреть", //+
				"noResults": "Нет результатов", //+
				"selectClassAndSubject": "Выберите класс и предмет", //+
				//Teacher Finish
				"testingResult": "Результат тестирования", //+
				"date": "Дата", //+
				"summary": "Итоги", //+
				"points": "Баллы", //+
				"false": "Неверно", //+
				"none": "Нет", //+
				"assessment": "Оценка", //+
				"detailedAnswers": "Ответы", //+
				"questions": "Вопросы", //+
				"answers": "Ответы", //+
				"isTrue": "Правильно ли", //+
				"times": "Время", //+
				"notFoundTesting": "Идентификатор теста %testingID% не найден!",

				//Teacher My Class
				"classTeacherSubject": "Выберите учителя по предмету", //+

				//Student signupLogin Namak
				"pleaseFillInAllTheFields": "Пожалуйста, заполните все поля", //+
				"thePasswordIsShort": "Кароткий пороль", //+
				"can'tBeTheSame": "Имя и фамилия не могут совпадать", //+
				"busyEmail": "Этот Email уже занят", //+
				"busyPassword": "Этот пароль уже занят", //+
				"passwordMustContain": "Пароль должен содержать 1 заглавную букву и не менее 1 из этих символов (!@#$%^&*)", //+
				"wrongEmail": "Электронная почта неверна", //+
				"signupSuccess": "Регистрация прошла успешно. Вы можете войти.", //+




				//Student signupLogin
				"studentLogin": "Вход", //+
				"studentSignup": "Регистрация", //+
				"fatherName": "Отчество", //+
				"wrongLogin": "Неверный вход", //+
				"wrongPassword": "Неверный пароль", //+
				"loginExists": "такой логин уже существует", //+
				//Student edu
				"enterPassword": "Введите пароль", //+
				"ok": "Подтвердить", //+
				"notLoggedIn": "Вы не авторизованы ", //+
				"waitUntilStart": "Дождитесь начала теста", //+
				//Student finish
				"youHaveNoResult": "Вы не участвовали в тесте или результат не сохранён", //+
				"maxPoints": "Максимальное количество баллов ", // очков ? +
				//Director signupLogin Namak
				"wrongLicense": "Нет такой лицензии", //+

				//Director signupLogin
				"directorLogin": "Войти", //+
				"directorSignup": "Регистрация", //+
				//Director testEdu
				"timer": "Таймер", //+
				"point": "Балл", //+
				"testEducation": "Тест", //+
				//Director School Classes
				"schoolClasses": "Классы в школе", //+
				"add": "Добавить", //+
				"change": "Изменить", //+
				"delete": "Удалить", //+
				"filter": "Искать", //+
				"selectTeacher": "Выберите Учителя", //+
				"classDeleteConfirm": "Вы уверены что хотите удалить класс %classNumber% %classGroup%?",  //+
				"addClass": "Добавить класс",  //+
				"editClass": "Редактировать класс",  //+
				"close": "Закрыть",  //+
				"update": "Обновить",  //+
			}
		},
		activeLang: {},
	},
	setActiveLang(newValue) {
		if (this.debug) console.log('setMessageAction triggered with', newValue)
		this.state.lang = newValue;
		this.state.activeLang = this.state.langs[newValue];
	},
	setLangs(langsValue) {
		this.state.langs = langsValue;
	},
	tr(key) {
		if (this.state.activeLang === {} || this.state.activeLang[key] === undefined) {
			return key;
        }
		return this.state.activeLang[key];
    }
}



var appLangSwitcher = new Vue({
	el: "#langSwitcher",
	data: {
		langState: langStore.state,
	},
	watch: {
		'langState.lang': function (newLang, oldLang) {
			localStorage.lang = newLang;
		},
	},
	methods: {
		setActiveLang: function (langKey) {
			langStore.setActiveLang(langKey);
		},
	},
	async created() {
		if (localStorage.lang) {
			this.setActiveLang(localStorage.lang);
		} else {
			this.setActiveLang('am');
        }
	},
	//mounted() {
	//	if (localStorage.lang) {
	//		this.setActiveLang(localStorage.lang);
	//	}
	//},
});