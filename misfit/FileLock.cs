using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Runtime.InteropServices;

namespace MISFIT
{
    public class FileLock
    {
        public const string LOCK_COLLISION = "LOCK_COLLISION";
        private List <string> LockedFileList = new List <string>();
        public const int HRESULT_FILE_EXISTS=-2147024816;
        public const int HRESULT_FILE_ACCESSDENIED = -2147024891;


        private static string GenerateLockName(string file)
        {
            return file + ".lck";
        }




        public static bool isLocked(string file)
        {
            return (File.Exists(GenerateLockName(file)));
        }

        public static FileInfo GetLockedFileInfo(string file)
        {
            FileInfo fi = null;
            if (FileLock.isLocked(file))
            {
                fi = new FileInfo(GenerateLockName(file));

            }
            return fi;
        }


        public static bool LockAdd(string file)
        {
            
            string fname = GenerateLockName(file);
            bool lock_established = false;

            for (int i = 0; i < 10; i++)
            {

                try
                {
                   // Debug.WriteLine("Locking " + file);
                    //using(FileStream fs = File.Open(fname, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                    //{
                    //    Byte[] info = new ASCIIEncoding().GetBytes("Locked File.. at " + DateTime.Now.ToString() + " by " + Globals.VERSION_MISFIT_STRING);
                    //    fs.Write(info, 0, info.Length);
                    //}
                    //System.Threading.Thread.Sleep(5);  //be sure the OS cleans up the file handle.
                    lock_established = true;
                  //  Debug.WriteLine("Locked " + file);
                    break;
                }

                catch (System.IO.IOException xIO)
                {

                    //-2147024816 hresult
                   
                 
                    Debug.WriteLine("on open " + xIO.Message);
                    Debug.WriteLine(xIO.InnerException);
                    int hr = Marshal.GetHRForException(xIO);
                    Debug.WriteLine("IO exception is " + hr.ToString());
                   // Debug.WriteLine(xIO.GetType().Name);
                    if (hr == HRESULT_FILE_EXISTS || hr==HRESULT_FILE_ACCESSDENIED)
                    {
                        Debug.WriteLine("Locked Failed on " + file + " will retry");
                        FileInfo fi = new FileInfo(fname);
                        if (fi.CreationTime.AddMinutes(15) < DateTime.Now)
                        {
                           // Debug.WriteLine("deleting stale lock file");
                            fi.Delete();
                        }
                       Globals.Sleep(100 * i);
                    }
                    else
                    {
                        throw xIO;
                    }

                }

               
            }





            if (!lock_established) //cannot lock a file that is already locked
            {

              //  Debug.WriteLine("NOPE! Locked Failed on " + file);

                throw new Exception(LOCK_COLLISION);

            }
            return true;  //if we got to here the status of the lock is applied so we return true indicating  IS locked. See FileLockRemove for inverse of this value

        }



        public static void LockRemove(string file)
        {
            File.Delete(GenerateLockName(file));
        }






        public void MultiLockByDirectoryList(ArrayList ListOfDirectories, string fileToLock)
        {
            Exception CaughtExcpetion = null;
            if (ListOfDirectories.Count==0)
                throw new Exception("MultiLockByDirectoryList cannot process an empty list");

            foreach (string DirectoryPath in ListOfDirectories)
            {

                try  //must catch exeptions here in order to rollback any locks.
                {
                    string fullName = DirectoryPath + "\\" + fileToLock;
                    LockAdd(fullName);
                    this.LockedFileList.Add(fullName);
                }
                catch (Exception E)
                {
                    CaughtExcpetion = E;
                    break;
                }
            }


            if (CaughtExcpetion != null)//rollback all locks cuz we bailing
            {
               // Debug.WriteLine("Rolling back all locks");
                foreach (string file in this.LockedFileList)
                {
                    FileLock.LockRemove(file);
                }
                this.LockedFileList.Clear();
                throw new Exception(CaughtExcpetion.Message);
            }

        }



        public void MultiLockByFileList(string DirectoryPath, ArrayList ListOfFilesToLock)
        {
            Exception CaughtExcpetion = null;
            if (ListOfFilesToLock.Count == 0)
                throw new Exception("MultiLockByFileList cannot process an empty list");



            foreach (string fileToLock in ListOfFilesToLock)
            {

                try  //must catch exeptions here in order to rollback any locks.
                {
                    string fullName = DirectoryPath + "\\" + fileToLock;
                    LockAdd(fullName);
                    this.LockedFileList.Add(fullName);
                }
                catch (Exception E)
                {
                    CaughtExcpetion = E;
                    break;
                }
            }


            if (CaughtExcpetion != null)//rollback all locks cuz we bailing
            {
                // Debug.WriteLine("Rolling back all locks");
                foreach (string file in this.LockedFileList)
                {
                    FileLock.LockRemove(file);
                }
                this.LockedFileList.Clear();
                throw new Exception(CaughtExcpetion.Message);
            }

        }




        public void MultiUnlock()
        {

            //if (this.LockedFileList.Count == 0)
              //  throw new Exception("MultiUnlock is trying to unlock and empty list");
            
            foreach (string file in this.LockedFileList)
            {
                FileLock.LockRemove(file);
            }
            this.LockedFileList.Clear();

        }


    }
}
