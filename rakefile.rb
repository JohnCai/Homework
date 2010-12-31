CONFIG = ENV['config'].nil? ? "debug" : ENV['config']
JUST_BUILD = ENV['rebuild'].nil?
NO_TEST = ENV['notest'].nil? ? false : true
CLR_TOOLS_VERSION = "v3.5"

#require "build_support/BuildUtils.rb"

NUNIT_PATH = "tools/NUnit/nunit-console.exe"

APP_SOLUTION = "src/SalesTaxes.App/SalesTaxes.App.sln"

props = { :stage => "build", :artifacts => "artifacts" ,:bin => "bin"}

include FileTest
require 'albacore'

task :default => ["build:all"]

namespace :build do  
  task :all => NO_TEST ? [:compile_all] : [:compile_all, :unit_test]  

  msbuild :compile_all => [:clean] do |msb|
	msb.use :net35	
    msb.properties :configurationi => CONFIG
	msb.targets JUST_BUILD ? :Build : :ReBuild
	msb.solution = APP_SOLUTION
	msb.verbosity = "normal"
  end 
  
  task :clean do
	#TODO: do any other tasks required to clean/prepare the working directory
	#Dir.mkdir props[:stage] unless exists?(props[:stage])
	#Dir.mkdir props[:artifacts] unless exists?(props[:artifacts])
	Dir.mkdir props[:bin] unless exists?(props[:bin])
  end
  
  desc "Runs unit tests"
  nunit :unit_test => :compile_all do |nunit|
    nunit.command = NUNIT_PATH
	nunit.assemblies File.join(props[:bin], "Debug/SalesTaxes.UnitTest.dll"), File.join(props[:bin], "Debug/SalesTaxes.AcceptanceTest.dll")
  end
  
  
  
  def copyOutputFiles(fromDir, filePattern, outDir)
  Dir.glob(File.join(fromDir, filePattern)){|file| 		
	copy(file, outDir) if File.file?(file)
  } 
  end
  
  
end