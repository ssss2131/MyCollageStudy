<template>
   <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm"  >
            <el-form-item label="用户名称" prop="name">
                <el-input v-model="ruleForm.name"></el-input>
            </el-form-item>
           <el-form-item label="用户邮箱" prop="email">
                <el-input v-model="ruleForm.email"></el-input>
            </el-form-item>
            <el-form-item label="出生日期" required>
                <el-col :span="11">
                <el-form-item prop="date1">
                    <el-date-picker type="date" placeholder="选择日期" v-model="ruleForm.date1" style="width: 100%;"></el-date-picker>
                </el-form-item>
                </el-col>             
            </el-form-item>
             
            <el-form-item label="用户性别" prop="sex">
                <el-radio-group v-model="ruleForm.sex">
                <el-radio label="男"></el-radio>
                <el-radio label="女"></el-radio>
                </el-radio-group>
            </el-form-item>
            <el-form-item label="收件地址" prop="address">
                <el-input type="textarea" v-model="ruleForm.address"></el-input>
            </el-form-item>
            <el-form-item>
              <!-- v-loading.fullscreen.lock="fullscreenLoading" -->
                <el-button type="primary" @click="submitForm('ruleForm')"  >确认信息</el-button>
                <el-button @click="resetForm('ruleForm')">重置</el-button>
            </el-form-item>
        </el-form>
</template>

<script>
export default {
     data() {
      return { fullscreenLoading: false,
        ruleForm: {
          name: '',
          email:'',
          region: '',
          date1: '',
          date2: '',
          sex: '',
          address: ''
        },
        rules: {
          name: [
            { required: true, message: '请输入用户名称', trigger: 'blur' },
            { min: 3, max: 5, message: '长度在 3 到 5 个字符', trigger: 'blur' }
          ],
           email: [
            { required: true, message: '请输入用户邮箱', trigger: 'blur' },
             { type: 'email', message: '请输入正确的邮箱地址', trigger: ['blur', 'change'] }
          ],
          region: [
            { required: true, message: '请选择活动区域', trigger: 'change' }
          ],
          date1: [
            { type: 'date', required: true, message: '请选择日期', trigger: 'change' }
          ],
          date2: [
            { type: 'date', required: true, message: '请选择时间', trigger: 'change' }
          ],
          type: [
            { type: 'array', required: true, message: '请至少选择一个活动性质', trigger: 'change' }
          ],
          sex: [
            { required: true, message: '请选择性别', trigger: 'change' }
          ],
          address: [
            { required: true, message: '请填写收件地址', trigger: 'blur' }
          ]
        }
      };
    },
    methods: {
      submitForm(formName) {
         
        this.$refs[formName].validate((valid) => {
          if (valid) {                   
             this.fullscreenLoading = true;
            setTimeout(() => {
            this.fullscreenLoading = false;
            this.$router.push('/signUp/confirmCode')
            }, 2000);                      
          } else {
            console.log('error submit!!');
            return false;
          }
        });
      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      }
    }
}
</script>

<style>

</style>