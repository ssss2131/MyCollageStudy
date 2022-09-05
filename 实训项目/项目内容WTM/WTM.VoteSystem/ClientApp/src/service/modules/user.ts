import config from "@/config/index";
const reqPath = config.headerApi + "/_Account/";
// 验证登陆
const loginCheckLogin = {
  url: reqPath + "CheckUserInfo",
  method: "get"
};
// 验证登出
const loginLogout = {
  url: reqPath + "Logout",
  method: "get"
};

const ChangePassword = {
  url: reqPath + "ChangePassword",
  method: "post"
};

export default {
  loginCheckLogin,
  loginLogout,
  ChangePassword
};
