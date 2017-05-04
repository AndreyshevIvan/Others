module.exports = function(grunt)
{
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        ts: {
            default: {
                src: ['ts/*.ts'],
                out: 'build/scripts.js',
                options: {
                    noImplicitAny: true,
                    removeComments: true,
                    preserveConstEnums: true,
                    sourceMap: false,
                    module: 'system',
                    target: 'es5'
                }
            }
        },

        tslint: {
            options:
                {
                    configFile: 'tsconfig.json'
                },
            validate: ['ts/*.ts']
        },

        clean: {
            allScripts: ['build/scripts.js'],
            js_min: ['build/*.js'],
            css_min: ['build/*.css']
        },

        connect: {
            server: {
                options: {
                    port: 8080,
                    base: '',
                    open: {
                        appName: 'Chrome'
                    }
                }
            }
        },

        uglify: {
            build: {
                src: 'build/scripts.js',
                dest: 'build/scripts.min.js'
            }
        },

        cssmin: {
            options: {
                mergeIntoShorthands: false,
                roundingPrecision: -1
            },

            target: {
                files: {
                    'build/styles.min.css': [
                        'css/main.css'
                    ]
                }
            }
        },

        hashres: {
            options: {
                fileNameFormat: '${name}.[${hash}].${ext}',
                renameFiles: true
            },

            prod: {
                src: [
                    'build/scripts.min.js',
                    'build/styles.min.css'
                ],

                dest: ['index.html']
            }
        },

        watch: {

            css: {
                files: ['css/**/*.*'],
                tasks: ['clean:css_min', 'cssmin', 'hashres:prod'],
                options: {livereload: true}
            },

            scripts: {
                files: ['ts/**/*.*', 'jsx/**/*.*'],
                tasks: ['clean:js_min',
                        'shell',
                        'tslint',
                        'ts',
                        'uglify',
                        'hashres:prod',
                        'clean:allScripts',
                ],
                options: {livereload: true}
            },

            html: {
                files: ['*.html'],
                options: {livereload: true}
            }
        },

        open: {
            dev: {
                path: 'http://localhost:8080/index.html'
            }
        },

        shell: {
            options: {
                stderr: true
            },
            target: {
                command: 'cspell ts/*.ts'
            }
        },
    });

    grunt.loadNpmTasks('grunt-ts'),
    grunt.loadNpmTasks('grunt-tslint');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-hashres');
    grunt.loadNpmTasks('grunt-open');
    grunt.loadNpmTasks('grunt-shell');

    grunt.registerTask('default', [
            'clean',
            'shell',
            'tslint',
            'ts',
            'uglify',
            'cssmin',
            'hashres:prod',
            'clean:allScripts',
            'connect:server',
            'watch'
    ]);
};