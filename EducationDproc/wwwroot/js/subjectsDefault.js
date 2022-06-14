var subjectsDefault = {
    subjects: [],
    country: '',

    countrySubjects: {
        armenia: [
            {
                classNumber: 1, subjects: [
                    'Մայրենի լեզու', 'Մաթեմատիկա', 'Երգ',
                    'Տեխնոլոգիա', 'Կերպարվեստ', 'Ֆիզկուլտուրա'
                ]
            },
            {
                classNumber: 2, subjects: [
                    'Մայրենի լեզու', 'Մաթեմատիկա', 'Ռուսաց լեզու', 'Շախմատ',
                    'Տեխնոլոգիա', 'Կերպարվեստ', 'Ֆիզկուլտուրա', 'Ես և շրջակա աշխարհ'
                ]
            },
            {
                classNumber: 3, subjects: [
                    'Մայրենի լեզու', 'Մաթեմատիկա', 'Ռուսաց լեզու', 'Շախմատ', 'Տեխնոլոգիա',
                    'Կերպարվեստ', 'Ֆիզկուլտուրա', 'Ես և շրջակա աշխարհ', 'Անգլերեն'
                ]
            },
            {
                classNumber: 4, subjects: [
                    'Մայրենի լեզու', 'Ռուսաց լեզու', 'Անգլերեն', 'Մաթեմատիկա', 'Տեխնոլոգիա',
                    'Շախմատ', 'Երգ', 'Կերպարվեստ', 'Ես և շրջակա աշխարհ', 'Ֆիզկուլտուրա'
                ]
            },
            {
                classNumber: 5, subjects: [
                    'Հայոց լեզու', 'Ռուսաց լեզու', 'Անգլերեն', 'Մաթեմատիկա', 'Տեխնոլոգիա',
                    'Երգ', 'Կերպարվեստ', 'Ֆիզկուլտուրա',
                    'Հայ եկեղեցու պատմություն', 'Բնագիտություն', 'Հայրենագիտություն'
                ]
            },
            {
                classNumber: 6, subjects: [
                    'Հայոց լեզու', 'Ռուսաց լեզու', 'Անգլերեն', 'Մաթեմատիկա', 'Տեխնոլոգիա',
                    'Երգ', 'Հայ եկեղեցու պատմություն', 'Բնագիտություն', 'Ինֆորմատիկա',
                    'Աշխարհագրություն', 'Հայոց պատմություն', 'Պատմություն', 'Ֆիզկուլտուրա'
                ]
            },
            {
                classNumber: 7, subjects: [
                    'Հայոց լեզու', 'Գրականություն', 'Ռուսաց լեզու', 'Անգլերեն', 'Հանրահաշիվ',
                    'Երկրաչափություն', 'Քիմիա', 'Ֆիզիկա', 'Տեխնոլոգիա', 'Աշխարհագրություն',
                    'Կենսաբանություն', 'Հայոց պատմություն', 'Հայ եկեղեցու պատմություն', 'Երաժշտություն',
                    'Ֆիզկուլտուրա'
                ]
            },
            {
                classNumber: 8, subjects: [
                    'Հայոց լեզու', 'Գրականություն', 'Ռուսաց լեզու', 'Անգլերեն', 'Հանրահաշիվ',
                    'Երկրաչափություն', 'Քիմիա', 'Ֆիզիկա', 'Ինֆորմատիկա', 'Աշխարհագրություն',
                    'Կենսաբանություն', 'Հայոց պատմություն', 'Հայ եկեղեցու պատմություն', 'Պատմություն',
                    'ՆԶՊ', 'Ֆիզկուլտուրա', 'Հասարակագիտություն'
                ]
            },
            {
                classNumber: 9, subjects: [
                    'Հայոց լեզու', 'Գրականություն', 'Ռուսաց լեզու', 'Անգլերեն', 'Հանրահաշիվ',
                    'Երկրաչափություն', 'Քիմիա', 'Ֆիզիկա', 'Հայոց պատմություն', 'Հայ եկեղեցու պատմություն', 'Պատմություն',
                    'Կենսաբանություն', 'ՆԶՊ', 'Ֆիզկուլտուրա', 'Հասարակագիտություն', 'Հայաստանի աշխարհագրություն'
                ]
            },
            {
                // kisat e !
                classNumber: 10, subjects: [
                    'Հայոց լեզու', 'Գրականություն', 'Ռուսաց լեզու', 'Անգլերեն', 'Հանրահաշիվ',
                    'Երկրաչափություն', 'Քիմիա', 'Ֆիզիկա',
                ]
            },
            {
                // kisat e !
                classNumber: 11, subjects: [
                    'Հայոց լեզու', 'Գրականություն', 'Ռուսաց լեզու', 'Անգլերեն', 'Հանրահաշիվ',
                    'Երկրաչափություն', 'Քիմիա', 'Ֆիզիկա',
                ]
            },
            {
                // kisat e !
                classNumber: 12, subjects: [
                    'Հայոց լեզու', 'Գրականություն', 'Ռուսաց լեզու', 'Անգլերեն', 'Հանրահաշիվ',
                    'Երկրաչափություն', 'Քիմիա', 'Ֆիզիկա',
                ]
            }
        ]
    },

    created() {
        this.setCountry('armenia');
        this.addSubjects();
    },

    setCountry(lang) {
        this.country = lang;
    },

    addSubjects() {
        this.getUnicalSubjects();
        console.log(this.subjects);
        this.subjects.forEach((s) => {
            axios({
                method: 'post',
                url: '/Subjects/addSubject',
                params: {
                    name: s,
                }
            }).then((r) => {
                this.subjectsIDS[s] = r.data.id;
                if (this.subjects.length === (Object.keys(this.subjectsIDS).length)) {
                    this.addClassNumberSubjects();
                }
            });
        });
    },

    getUnicalSubjects() {
        this.subjects = [];
        this.subjectsIDS = {};
        let subjectsNotUnical = this.countrySubjects[this.country].map((item) => { return item.subjects }).flat();

        let subjectsUnical = [
            ...new Map(subjectsNotUnical.map((item) => [item, item])).values(),
        ];

        //console.log(subjectsUnical);
        this.subjects = [...subjectsUnical];

        //subjectsUnical.forEach((item) => {
        //    this.subjects[item] = 0;
        //});
    },

    addClassNumberSubjects() {
        this.countrySubjects[this.country].forEach((classSubject) => {
            classSubject.subjects.forEach((s) => {
                axios({
                    method: 'post',
                    url: '/Subjects/addClassNumberSubject',
                    params: {
                        classNumber: classSubject.classNumber,
                        subjectID: this.subjectsIDS[s]
                    }
                }).then((r) => {
                    console.log(classSubject.classNumber, s, this.subjectsIDS[s], r.data.id);
                });
            });
        });
    },
}

console.log('for insert subjects you must log in as director or teacher. so in C# must be schoolId parametr');