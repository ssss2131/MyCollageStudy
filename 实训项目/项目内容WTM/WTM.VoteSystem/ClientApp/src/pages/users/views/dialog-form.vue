<template>
    <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
        <wtm-create-form :ref="refName" :status="status" :options="formOptions" ></wtm-create-form>
    </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";
import { YourRoleTypes,YourSexTypes } from "../config";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {

    // 表单结构
    get formOptions() {
        const filterMethod = (query, item) => {
            return item.label.indexOf(query) > -1;
        };
        return {
            formProps: {
                "label-width": "100px"
            },
            formItem: {
                "Entity.ID": {
                    isHidden: true
                },
             "Entity.YourRole":{
                 label: "你的角色",
                 rules: [{ required: true, message: "你的角色"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: YourRoleTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.Account":{
                 label: "账户",
                 rules: [{ required: true, message: "账户"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Password":{
                 label: "密码",
                 rules: [{ required: true, message: "密码"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Name":{
                 label: "姓名",
                 rules: [{ required: true, message: "姓名"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.YourSex":{
                 label: "性别",
                 rules: [{ required: true, message: "性别"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: YourSexTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.Img":{
                 label: "图片",
                 rules: [],
                    type: "input"
            },
             "Entity.Age":{
                 label: "年龄",
                 rules: [{ required: true, message: "年龄"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Introduce":{
                 label: "简介",
                 rules: [],
                    type: "input"
            },
             "Entity.Birthday":{
                 label: "生日",
                 rules: [],
                    type: "datePicker"
            },
             "Entity.PhoneNumber":{
                 label: "电话号码",
                 rules: [{ required: true, message: "电话号码"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Email":{
                 label: "邮箱",
                 rules: [{ required: true, message: "邮箱"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            }
                
            }
        };
    }
    beforeOpen() {

    }
}
</script>
