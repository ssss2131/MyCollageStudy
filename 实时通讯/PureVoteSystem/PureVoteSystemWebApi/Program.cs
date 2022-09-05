
using PureVoteSystem.EfCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("policy1", builder =>
    {
        builder.WithOrigins("http://localhost:8083","http://localhost:8084","http://localhost:8085").AllowAnyMethod().AllowAnyHeader();
    });
});
// Add services to the container.
#region ʹ��AutoMapper
// ����������Assembly���͵����� ��ʾAutoMapper������Щ���������������Ѱ�����м̳���Profile��������ļ�
// �ڵ�ǰ����������г�������ɨ��AutoMapper�������ļ�
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("policy1");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
