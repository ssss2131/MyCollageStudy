import i18n from "@/lang";

export const ASSEMBLIES: Array<string> = [
  "add",
  "edit",
  "delete",
  "export",
  "imported"
];

export const TABLE_HEADER: Array<object> = [


    {
        key: "YourRole",
        label: "你的角色"
    },
    {
        key: "Account",
        label: "账户"
    },
    {
        key: "Password",
        label: "密码"
    },
    {
        key: "Name",
        label: "姓名"
    },
    {
        key: "YourSex",
        label: "性别"
    },
    {
        key: "Img",
        label: "图片"
    },
    {
        key: "Age",
        label: "年龄"
    },
    {
        key: "Introduce",
        label: "简介"
    },
    {
        key: "Birthday",
        label: "生日"
    },
    {
        key: "PhoneNumber",
        label: "电话号码"
    },
    {
        key: "Email",
        label: "邮箱"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const YourRoleTypes: Array<any> = [
  { Text: "Voter", Value: "Voter" },
  { Text: "Candidate", Value: "Candidate" },
  { Text: "Manager", Value: "Manager" }
];
export const YourSexTypes: Array<any> = [
  { Text: "男", Value: "男" },
  { Text: "女", Value: "女" }
];

