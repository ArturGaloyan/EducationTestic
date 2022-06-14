var appMenu = new Vue({
    el: "#headerMenu",
    data: {
        menuType: null,
        hasClass: 0,
        ls: langStore, // translation
    },
    methods: {

        logout: function () {           
            axios({
                method: 'get',
                url: '/Menu/Logout',
            }).then((r) => {
                //window.location = (this.menuType == 'student') ? '/StudentsSignupLogin/Index' : '/AuthorSignupLogin/Index';

                switch (this.menuType) {
                    case 'student':
                        window.location = ('/Student/SignupLogin');
                        break;
                    case 'teacher':
                        window.location = ('/Teacher/SignupLogin');
                        break;
                    case 'director':
                        window.location = ('/Director/SignupLogin');
                        break;
                    default:
                        break;
                }

                //if (this.menuType == 'student') {
                //    window.location = ('/StudentsSignupLogin/Index');
                //}
                //else if (this.menuType == 'teacher') {
                //    window.location = ('/TeacherSignupLogin/Index');
                //}
                //else if (this.menuType == 'director') {
                //    window.location = ('/Director/SignupLogin');
                //}
            });
        },
    },

    async created() {
        axios({
            method: 'get',
            url: '/Menu/GetMenuType',
            params: {

            }
        }).then((r) => {
            console.log(r.data);
            this.menuType = r.data.menuType;
            if (!!r.data.hasClass) {
                this.hasClass = r.data.hasClass;
            }
        });
    },

});