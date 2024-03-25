using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCoreUserProfile.Models;

public partial class UserProfileDbContext : DbContext
{
    public UserProfileDbContext()
    {
    }

    public UserProfileDbContext(DbContextOptions<UserProfileDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblContentQuestion> TblContentQuestions { get; set; }

    public virtual DbSet<TblTopic> TblTopics { get; set; }

    public virtual DbSet<TblTopicContent> TblTopicContents { get; set; }

    public virtual DbSet<TblUserExam> TblUserExams { get; set; }

    public virtual DbSet<TblUserExamQuestion> TblUserExamQuestions { get; set; }

    public virtual DbSet<Tblcity> Tblcities { get; set; }

    public virtual DbSet<Tbldesignation> Tbldesignations { get; set; }

    public virtual DbSet<Tblgender> Tblgenders { get; set; }

    public virtual DbSet<Tblqualification> Tblqualifications { get; set; }

    public virtual DbSet<TbluserDetail> TbluserDetails { get; set; }

    public virtual DbSet<TbluserExperience> TbluserExperiences { get; set; }

    public virtual DbSet<TbluserExperienceProject> TbluserExperienceProjects { get; set; }

    public virtual DbSet<TbluserHobby> TbluserHobbies { get; set; }

    public virtual DbSet<TbluserObjective> TbluserObjectives { get; set; }

    public virtual DbSet<TbluserProjectResponsibility> TbluserProjectResponsibilities { get; set; }

    public virtual DbSet<TbluserQualification> TbluserQualifications { get; set; }

    public virtual DbSet<TbluserSkill> TbluserSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FF8E3E6\\SQLEXPRESS;Database=UserProfileDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblContentQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__tblConte__B0B3E0BE221381A7");

            entity.ToTable("tblContent_questions");

            entity.Property(e => e.QuestionId).HasColumnName("Question_id");
            entity.Property(e => e.ContentId).HasColumnName("Content_id");
            entity.Property(e => e.CorrectOptionNumber).HasColumnName("Correct_option_number");
            entity.Property(e => e.Option1)
                .IsUnicode(false)
                .HasColumnName("Option_1");
            entity.Property(e => e.Option2)
                .IsUnicode(false)
                .HasColumnName("Option_2");
            entity.Property(e => e.Option3)
                .IsUnicode(false)
                .HasColumnName("Option_3");
            entity.Property(e => e.Option4)
                .IsUnicode(false)
                .HasColumnName("Option_4");
            entity.Property(e => e.Question).IsUnicode(false);

            entity.HasOne(d => d.Content).WithMany(p => p.TblContentQuestions)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("fkcid");
        });

        modelBuilder.Entity<TblTopic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__tblTopic__8DEBA02D392BB9F7");

            entity.ToTable("tblTopics");

            entity.Property(e => e.TopicId).HasColumnName("Topic_id");
            entity.Property(e => e.TopicName)
                .IsUnicode(false)
                .HasColumnName("Topic_name");
        });

        modelBuilder.Entity<TblTopicContent>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__tblTopic__4F5DE4DDF143B083");

            entity.ToTable("tblTopic_contents");

            entity.Property(e => e.ContentId).HasColumnName("Content_id");
            entity.Property(e => e.ContentName)
                .IsUnicode(false)
                .HasColumnName("Content_name");
            entity.Property(e => e.TopicId).HasColumnName("Topic_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.TblTopicContents)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("fktid");
        });

        modelBuilder.Entity<TblUserExam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__tblUser___C79BD671252059B4");

            entity.ToTable("tblUser_exams");

            entity.Property(e => e.ExamId).HasColumnName("Exam_id");
            entity.Property(e => e.EndTime)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("End_time");
            entity.Property(e => e.ExamDate)
                .HasColumnType("date")
                .HasColumnName("Exam_date");
            entity.Property(e => e.StartTime)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Start_time");
            entity.Property(e => e.TopicId).HasColumnName("Topic_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.TblUserExams)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("fkt_id");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserExams)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tblUser_e__user___778AC167");
        });

        modelBuilder.Entity<TblUserExamQuestion>(entity =>
        {
            entity.HasKey(e => e.ExamQuestionId).HasName("PK__tblUser___C11D50AC3FBD0E4E");

            entity.ToTable("tblUser_exam_questions");

            entity.Property(e => e.ExamQuestionId).HasColumnName("Exam_question_id");
            entity.Property(e => e.ExamId).HasColumnName("Exam_id");
            entity.Property(e => e.QuestionId).HasColumnName("Question_id");
            entity.Property(e => e.SubmitedOptionNumber).HasColumnName("Submited_option_number");

            entity.HasOne(d => d.Exam).WithMany(p => p.TblUserExamQuestions)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("fkeid");

            entity.HasOne(d => d.Question).WithMany(p => p.TblUserExamQuestions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fkqid");
        });

        modelBuilder.Entity<Tblcity>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__tblcitie__031491A84D1C7710");

            entity.ToTable("tblcities");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Tbldesignation>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__tbldesig__177649C11B6C47CF");

            entity.ToTable("tbldesignations");

            entity.Property(e => e.DesignationId).HasColumnName("designation_id");
            entity.Property(e => e.DesignationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("designation_name");
        });

        modelBuilder.Entity<Tblgender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__tblgende__9DF18F87EF9C8D53");

            entity.ToTable("tblgenders");

            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Tblqualification>(entity =>
        {
            entity.HasKey(e => e.QualificationId).HasName("PK__tblquali__CDACC5DBB871F513");

            entity.ToTable("tblqualifications");

            entity.Property(e => e.QualificationId).HasColumnName("qualification_id");
            entity.Property(e => e.Qualification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("qualification");
        });

        modelBuilder.Entity<TbluserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbluser___B9BE370FF40594D9");

            entity.ToTable("tbluser_details");

            entity.HasIndex(e => e.EmailAddress, "UQ__tbluser___20C6DFF526A2F0BF").IsUnique();

            entity.HasIndex(e => e.MobileNumber, "UQ__tbluser___30462B0FFEEF0DCF").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__tbluser___7C9273C44C742BFD").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_address");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePhoto)
                .IsUnicode(false)
                .HasColumnName("profile_photo");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Gender).WithMany(p => p.TbluserDetails)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__tbluser_d__gende__5441852A");
        });

        modelBuilder.Entity<TbluserExperience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("PK__tbluser___EB216AFC0C4F474D");

            entity.ToTable("tbluser_experiences");

            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.DesignationId).HasColumnName("designation_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Designation).WithMany(p => p.TbluserExperiences)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK__tbluser_e__desig__5AEE82B9");

            entity.HasOne(d => d.User).WithMany(p => p.TbluserExperiences)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tbluser_e__user___59FA5E80");
        });

        modelBuilder.Entity<TbluserExperienceProject>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__tbluser___BC799E1FB6CBF8F2");

            entity.ToTable("tbluser_experience_project");

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("client_name");
            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.FromDate)
                .HasColumnType("date")
                .HasColumnName("from_date");
            entity.Property(e => e.Project)
                .IsUnicode(false)
                .HasColumnName("project");
            entity.Property(e => e.ProjectDescription)
                .IsUnicode(false)
                .HasColumnName("project_description");
            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("to_date");

            entity.HasOne(d => d.Experience).WithMany(p => p.TbluserExperienceProjects)
                .HasForeignKey(d => d.ExperienceId)
                .HasConstraintName("FK__tbluser_e__exper__5DCAEF64");
        });

        modelBuilder.Entity<TbluserHobby>(entity =>
        {
            entity.HasKey(e => e.HobbyId).HasName("PK__tbluser___ABCB3D343DD6C4FE");

            entity.ToTable("tbluser_hobbies");

            entity.Property(e => e.HobbyId).HasColumnName("hobby_id");
            entity.Property(e => e.Hobby)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hobby");
        });

        modelBuilder.Entity<TbluserObjective>(entity =>
        {
            entity.HasKey(e => e.ObjectiveId).HasName("PK__tbluser___21116A6656F3F3C8");

            entity.ToTable("tbluser_objectives");

            entity.Property(e => e.ObjectiveId).HasColumnName("objective_id");
            entity.Property(e => e.Objective)
                .IsUnicode(false)
                .HasColumnName("objective");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.TbluserObjectives)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tbluser_o__user___656C112C");
        });

        modelBuilder.Entity<TbluserProjectResponsibility>(entity =>
        {
            entity.HasKey(e => e.ResponsibilityId).HasName("PK__tbluser___0FD26EB9984E1884");

            entity.ToTable("tbluser_project_responsibilities");

            entity.Property(e => e.ResponsibilityId).HasColumnName("responsibility_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Responsibility)
                .IsUnicode(false)
                .HasColumnName("responsibility");

            entity.HasOne(d => d.Project).WithMany(p => p.TbluserProjectResponsibilities)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__tbluser_p__proje__60A75C0F");
        });

        modelBuilder.Entity<TbluserQualification>(entity =>
        {
            entity.HasKey(e => e.UserQualificationId).HasName("PK__tbluser___6B4B313D549AFC73");

            entity.ToTable("tbluser_qualifications");

            entity.Property(e => e.UserQualificationId).HasColumnName("user_qualification_id");
            entity.Property(e => e.Medium)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("medium");
            entity.Property(e => e.PassingYear).HasColumnName("passing_year");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.QualificationId).HasColumnName("qualification_id");
            entity.Property(e => e.University)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("university");

            entity.HasOne(d => d.Qualification).WithMany(p => p.TbluserQualifications)
                .HasForeignKey(d => d.QualificationId)
                .HasConstraintName("FK__tbluser_q__quali__571DF1D5");
        });

        modelBuilder.Entity<TbluserSkill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__tbluser___FBBA8379D6549B33");

            entity.ToTable("tbluser_skills");

            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.SkillTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("skill_title");
            entity.Property(e => e.Skills)
                .IsUnicode(false)
                .HasColumnName("skills");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.TbluserSkills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tbluser_s__user___68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
