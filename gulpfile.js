var gulp        = require('gulp')
,   browserSync = require('browser-sync').create()
,   concat      = require('gulp-concat')
,   sass        = require('gulp-sass')
,   uglify      = require('gulp-uglify')
;

var paths = {
    src  : './app',
    dest : './dist'
};

gulp.task('html', function() {
    return gulp.src(paths.src + '/*.html')
             .pipe(gulp.dest(paths.dest));
});

gulp.task('img', function() {
    return gulp.src(paths.src + '/img/**/*.*')
             .pipe(gulp.dest(paths.dest + '/img'));
});

gulp.task('fonts', function() {
    return gulp.src('./node_modules/roboto-fontface/fonts/roboto/*.*')
             .pipe(gulp.dest('./wwwroot/fonts/roboto'));
});

gulp.task('sass', ['fonts'], function() {
    return gulp.src('./wwwroot/css/*.scss')
             .pipe(sass())
             .pipe(gulp.dest('./wwwroot/css'))
             .pipe(browserSync.stream());
           ;
});

gulp.task('js', function() {
    return gulp.src(['./node_modules/jquery/dist/jquery.min.js', './node_modules/moment/min/moment.min.js', './wwwroot/js/weatherapp.js'])
        .pipe(concat('scripts.js'))
        .pipe(uglify())
        .pipe(gulp.dest('./wwwroot/js'));
});

gulp.task('build', ['html','img','sass', 'js'], function() {



});


gulp.task('watch-sass', ['sass'], function() {
    gulp.watch("wwwroot/css/*.scss", ['sass']);
});

// TODO: Out of date, using static files and we've moved on to .NET
gulp.task('serve', ['build'], function() {

    browserSync.init({
        server: paths.dest
    });

    gulp.watch("app/sass/*.scss", ['sass']);
    gulp.watch([paths.src + "/*.html", paths.src + "/js/**.*/*.js"], ['build','sass'])
          .on('change', browserSync.reload);



});