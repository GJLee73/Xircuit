#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("uVfew24grfZ1pq3Ip1zHp/xDh++P29OvOI4xHrUypCmYQDCObkCn2zn2UVaco+Dy7v5yFvwKi7nznrDTLNxm2R3kWlSNX8GTvA3B4ZfKfDQVXwP4FwVCJ7sq61pDETtVIEeYBN9zYg3QgFCyD2EBrEFY3qhrqdyMa+jm6dlr6OPra+jo6WNu8gRJbIo58VAlCJ4N64NwMvb1VkMOWi9cvCzZI3LWJSLOUZ7aNA5hBWBGcPWx5hNaW8PgJ1y9jgCxLaCo5Mv79wDZa+jL2eTv4MNvoW8e5Ojo6Ozp6tb33fS/fHwvW1AzdldttNra8p3xPo1d7uyhN+5GweIGV4jqgO9aGijiEr5umZefn8SGGNxJZ90QjV+BKNxDH7E35UwZQOvq6Ono");
        private static int[] order = new int[] { 5,11,6,6,9,12,11,11,9,9,12,13,12,13,14 };
        private static int key = 233;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
