var subjects = {
    subjects: [],
    classNumberSubjects: [],
    classSubjects: [
        {classNumber: 1, subjects: []},
        {classNumber: 2, subjects: []},
        {classNumber: 3, subjects: []},
        {classNumber: 4, subjects: []},
        {classNumber: 5, subjects: []},
        {classNumber: 6, subjects: []},
        {classNumber: 7, subjects: []},
        {classNumber: 8, subjects: []},
        {classNumber: 9, subjects: []},
        {classNumber: 10, subjects: []},
        {classNumber: 11, subjects: []},
        {classNumber: 12, subjects: []}
    ],
    getSubjects() {
        axios({
            method: 'get',
            url: '/Subjects/getSubjects',
        }).then((r) => {
            this.subjects = r.data.subjects;
            this.classNumberSubjects = r.data.classNumberSubjects;
            r.data.classNumberSubjects.forEach((classNumberSubject) => {
                let i = this.classSubjects.findIndex((item) => { return classNumberSubject.classNumber == item.classNumber });
                this.classSubjects[i].subjects.push(classNumberSubject.subject);
            });
            return r;
        });
    }
}
subjects.getSubjects(); // stanal dproci bolor ararkaner@@ sharac @@st dasaranneri
