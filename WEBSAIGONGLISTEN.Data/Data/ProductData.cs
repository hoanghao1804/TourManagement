using WEBSAIGONGLISTEN.Models;

namespace WEBSAIGONGLISTEN.Data.Data
{
    public static class ProductData
    {
        public static List<Product> GetProducts(List<Category> categories)
        {
            return new List<Product>
            {
                // MIỀN BẮC - 5 TOURS
                new Product
                {
                    Name = "Tour Hà Nội - Sapa - Hạ Long 5N4Đ",
                    Description = "Khám phá vẻ đẹp thiên nhiên hùng vĩ của miền Bắc với tour Sapa và vịnh Hạ Long. Trải nghiệm cuộc sống của người dân tộc thiểu số, ngắm ruộng bậc thang tuyệt đẹp và thưởng thức phong cảnh kỳ vĩ của vịnh Hạ Long - Di sản thế giới.",
                    ImageUrl = "/images/sapa-halong.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Bắc").Id,
                    Quantity = 20,
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(34),
                    PriceUnder2 = 500000,
                    Price2To10 = 2500000,
                    PriceAbove10 = 3500000,
                    Latitude = 20.9101,
                    Longitude = 107.1839,
                    Address = "Vịnh Hạ Long",
                    City = "Hạ Long",
                    Province = "Quảng Ninh"
                },
                new Product
                {
                    Name = "Tour Hà Nội - Ninh Bình - Tam Cốc 3N2Đ",
                    Description = "Khám phá vùng đất cố đô với tour Ninh Bình. Tham quan chùa Bái Đính, thuyền trên sông Tam Cốc, và leo núi Tràng An để ngắm toàn cảnh tuyệt đẹp.",
                    ImageUrl = "/images/ninhbinh-tamcoc.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Bắc").Id,
                    Quantity = 25,
                    StartDate = DateTime.Now.AddDays(40),
                    EndDate = DateTime.Now.AddDays(42),
                    PriceUnder2 = 350000,
                    Price2To10 = 1800000,
                    PriceAbove10 = 2500000,
                    Latitude = 20.2149,
                    Longitude = 105.9741,
                    Address = "Tam Cốc - Bích Động",
                    City = "Ninh Bình",
                    Province = "Ninh Bình"
                },
                new Product
                {
                    Name = "Tour Hà Nội - Mù Cang Chải - Yên Bái 4N3Đ",
                    Description = "Chinh phục những con đèo đẹp nhất Việt Nam với tour Mù Cang Chải. Ngắm ruộng bậc thang vào mùa lúa chín vàng, trải nghiệm cuộc sống người Mông.",
                    ImageUrl = "/images/mucangchai.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Bắc").Id,
                    Quantity = 15,
                    StartDate = DateTime.Now.AddDays(50),
                    EndDate = DateTime.Now.AddDays(53),
                    PriceUnder2 = 400000,
                    Price2To10 = 2200000,
                    PriceAbove10 = 3000000,
                    Latitude = 21.7858,
                    Longitude = 104.1413,
                    Address = "Mù Cang Chải",
                    City = "Mù Cang Chải",
                    Province = "Yên Bái"
                },
                new Product
                {
                    Name = "Tour Hà Nội - Mai Châu - Hòa Bình 3N2Đ",
                    Description = "Thư giãn tại thung lũng Mai Châu xanh mát. Trải nghiệm homestay tại nhà sàn người Thái, thưởng thức ẩm thực địa phương và tham gia các hoạt động văn hóa.",
                    ImageUrl = "/images/maichau.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Bắc").Id,
                    Quantity = 30,
                    StartDate = DateTime.Now.AddDays(25),
                    EndDate = DateTime.Now.AddDays(27),
                    PriceUnder2 = 300000,
                    Price2To10 = 1500000,
                    PriceAbove10 = 2000000,
                    Latitude = 20.6585,
                    Longitude = 105.1096,
                    Address = "Mai Châu",
                    City = "Mai Châu",
                    Province = "Hòa Bình"
                },
                new Product
                {
                    Name = "Tour Hà Nội - Quảng Ninh 4N3Đ",
                    Description = "Khám phá vịnh Bái Tử Long ít người biết đến. Tham quan các đảo hoang sơ, tắm biển và thưởng thức hải sản tươi ngon tại vịnh biển đẹp.",
                    ImageUrl = "/images/baitulong.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Bắc").Id,
                    Quantity = 18,
                    StartDate = DateTime.Now.AddDays(35),
                    EndDate = DateTime.Now.AddDays(38),
                    PriceUnder2 = 450000,
                    Price2To10 = 2300000,
                    PriceAbove10 = 3200000,
                    Latitude = 20.7890,
                    Longitude = 107.5146,
                    Address = "Vịnh Bái Tử Long",
                    City = "Vân Đồn",
                    Province = "Quảng Ninh"
                },

                // MIỀN TRUNG - 5 TOURS
                new Product
                {
                    Name = "Tour Đà Nẵng - Hội An - Huế 4N3Đ",
                    Description = "Khám phá di sản văn hóa thế giới với tour miền Trung. Tham quan phố cổ Hội An lung linh về đêm, khám phá cố đô Huế với những công trình kiến trúc cổ kính, và tận hưởng bãi biển Đà Nẵng tuyệt đẹp.",
                    ImageUrl = "/images/hue-hoian-danang.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Trung").Id,
                    Quantity = 25,
                    StartDate = DateTime.Now.AddDays(45),
                    EndDate = DateTime.Now.AddDays(48),
                    PriceUnder2 = 400000,
                    Price2To10 = 2000000,
                    PriceAbove10 = 2800000,
                    Latitude = 16.0544,
                    Longitude = 108.2022,
                    Address = "Cầu Vàng, Bà Nà Hills",
                    City = "Hòa Ninh",
                    Province = "Đà Nẵng"
                },
                new Product
                {
                    Name = "Tour Đà Nẵng - Bà Nà Hills - Cầu Vàng 3N2Đ",
                    Description = "Trải nghiệm 'thiên đường trên mây' tại Bà Nà Hills. Đi cáp treo dài nhất thế giới, check-in tại Cầu Vàng nổi tiếng và tham quan làng Pháp cổ kính.",
                    ImageUrl = "/images/banahills.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Trung").Id,
                    Quantity = 35,
                    StartDate = DateTime.Now.AddDays(20),
                    EndDate = DateTime.Now.AddDays(22),
                    PriceUnder2 = 350000,
                    Price2To10 = 1800000,
                    PriceAbove10 = 2500000,
                    Latitude = 16.0460,
                    Longitude = 108.1813,
                    Address = "Cầu Vàng, Bà Nà Hills",
                    City = "Hòa Ninh",
                    Province = "Đà Nẵng"
                },
                new Product
                {
                    Name = "Tour Quy Nhon - Phú Yên - Tuy Hòa 4N3Đ",
                    Description = "Khám phá bờ biển miền Trung hoang sơ. Tham quan Gành Đá Dĩa độc đáo, tắm biển Quy Nhơn trong xanh và thưởng thức ẩm thực biển tươi ngon.",
                    ImageUrl = "/images/quynhon-phuyen.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Trung").Id,
                    Quantity = 22,
                    StartDate = DateTime.Now.AddDays(55),
                    EndDate = DateTime.Now.AddDays(58),
                    PriceUnder2 = 380000,
                    Price2To10 = 1900000,
                    PriceAbove10 = 2600000,
                    Latitude = 13.7977,
                    Longitude = 109.2368,
                    Address = "Gành Đá Dĩa",
                    City = "Tuy An",
                    Province = "Phú Yên"
                },
                new Product
                {
                    Name = "Tour Nha Trang - Đà Lạt 5N4Đ",
                    Description = "Kết hợp biển và núi trong một tour. Tắm biển Nha Trang, tham quan Vinpearl Land và sau đó lên Đà Lạt thưởng thức không khí mát mẻ, tham quan các điểm du lịch nổi tiếng.",
                    ImageUrl = "/images/nhatrang-dalat.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Trung").Id,
                    Quantity = 28,
                    StartDate = DateTime.Now.AddDays(40),
                    EndDate = DateTime.Now.AddDays(44),
                    PriceUnder2 = 450000,
                    Price2To10 = 2300000,
                    PriceAbove10 = 3200000,
                    Latitude = 12.2388,
                    Longitude = 109.1967,
                    Address = "Vinpearl Land",
                    City = "Nha Trang",
                    Province = "Khánh Hòa"
                },
                new Product
                {
                    Name = "Tour Đà Lạt - Đơn Dương - Lâm Đồng 4N3Đ",
                    Description = "Khám phá 'thành phố ngàn hoa' Đà Lạt. Tham quan thung lũng Tình Yêu, hồ Xuân Hương, chợ Đà Lạt về đêm và trải nghiệm canh tác nông nghiệp tại Đơn Dương.",
                    ImageUrl = "/images/dalat.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Trung").Id,
                    Quantity = 32,
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(33),
                    PriceUnder2 = 320000,
                    Price2To10 = 1600000,
                    PriceAbove10 = 2200000,
                    Latitude = 11.9404,
                    Longitude = 108.4583,
                    Address = "Thung lũng Tình Yêu",
                    City = "Đà Lạt",
                    Province = "Lâm Đồng"
                },

                // MIỀN NAM - 5 TOURS
                new Product
                {
                    Name = "Tour TP.HCM - Cần Thơ - Châu Đốc 3N2Đ",
                    Description = "Trải nghiệm miền Tây sông nước với tour Mekong Delta. Khám phá chợ nổi Cái Răng, tham quan khu du lịch sinh thái, và tìm hiểu văn hóa đặc trưng của vùng đất phương Nam.",
                    ImageUrl = "/images/mekong-delta.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Nam").Id,
                    Quantity = 30,
                    StartDate = DateTime.Now.AddDays(20),
                    EndDate = DateTime.Now.AddDays(22),
                    PriceUnder2 = 300000,
                    Price2To10 = 1500000,
                    PriceAbove10 = 2200000,
                    Latitude = 9.7947,
                    Longitude = 105.1154,
                    Address = "Chợ nổi Cái Răng",
                    City = "Cái Răng",
                    Province = "Cần Thơ"
                },
                new Product
                {
                    Name = "Tour TP.HCM - Bến Tre - Tiền Giang 2N1Đ",
                    Description = "Khám phá xứ dừa Bến Tre. Đi xuồng ba lá trên sông, tham quan các làng nghề truyền thống, thưởng thức kẹo dừa và trải nghiệm cuộc sống miền Tây.",
                    ImageUrl = "/images/bentre.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Nam").Id,
                    Quantity = 40,
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(16),
                    PriceUnder2 = 250000,
                    Price2To10 = 1200000,
                    PriceAbove10 = 1800000,
                    Latitude = 10.2415,
                    Longitude = 106.3750,
                    Address = "Cù Lao Bến Tre",
                    City = "Châu Thành",
                    Province = "Bến Tre"
                },
                new Product
                {
                    Name = "Tour TP.HCM - Côn Đảo - Vũng Tàu 4N3Đ",
                    Description = "Khám phá đảo thiêng Côn Đảo. Tham quan nhà tù Côn Đảo, tắm biển trong xanh, thưởng thức hải sản tươi ngon và trải nghiệm cuộc sống đảo biệt lập.",
                    ImageUrl = "/images/condao.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Nam").Id,
                    Quantity = 15,
                    StartDate = DateTime.Now.AddDays(60),
                    EndDate = DateTime.Now.AddDays(63),
                    PriceUnder2 = 500000,
                    Price2To10 = 2800000,
                    PriceAbove10 = 3800000,
                    Latitude = 8.6833,
                    Longitude = 106.6167,
                    Address = "Côn Đảo",
                    City = "Côn Đảo",
                    Province = "Bà Rịa - Vũng Tàu"
                },
                new Product
                {
                    Name = "Tour TP.HCM - Đồng Tháp - Long An 3N2Đ",
                    Description = "Khám phá vùng đất ngập nước Đồng Tháp Mười. Tham quan vườn quốc gia Tràm Chim, ngắm chim cò và trải nghiệm cuộc sống nông nghiệp vùng đồng bằng.",
                    ImageUrl = "/images/dongthap.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Nam").Id,
                    Quantity = 25,
                    StartDate = DateTime.Now.AddDays(35),
                    EndDate = DateTime.Now.AddDays(37),
                    PriceUnder2 = 280000,
                    Price2To10 = 1400000,
                    PriceAbove10 = 2000000,
                    Latitude = 10.8706,
                    Longitude = 105.4647,
                    Address = "Vườn quốc gia Tràm Chim",
                    City = "Tam Nông",
                    Province = "Đồng Tháp"
                },
                new Product
                {
                    Name = "Tour TP.HCM - Phú Quốc 3N2Đ",
                    Description = "Khám phá đảo ngọc Phú Quốc. Tắm biển tại các bãi biển đẹp nhất, tham quan nhà tù Phú Quốc, thưởng thức nước mắm Phú Quốc và ngắm hoàng hôn tuyệt đẹp.",
                    ImageUrl = "/images/phuquoc.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch miền Nam").Id,
                    Quantity = 20,
                    StartDate = DateTime.Now.AddDays(25),
                    EndDate = DateTime.Now.AddDays(27),
                    PriceUnder2 = 400000,
                    Price2To10 = 2200000,
                    PriceAbove10 = 3000000,
                    Latitude = 10.2899,
                    Longitude = 103.9840,
                    Address = "Bãi Khem",
                    City = "An Thới",
                    Province = "Kiên Giang"
                },

                // NƯỚC NGOÀI - 5 TOURS
                new Product
                {
                    Name = "Tour Singapore - Malaysia 5N4Đ",
                    Description = "Khám phá hai quốc gia phát triển bậc nhất Đông Nam Á. Tham quan những công trình kiến trúc hiện đại, trải nghiệm ẩm thực đa dạng và mua sắm tại các trung tâm thương mại nổi tiếng.",
                    ImageUrl = "/images/singapore-malaysia.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch nước ngoài").Id,
                    Quantity = 15,
                    StartDate = DateTime.Now.AddDays(60),
                    EndDate = DateTime.Now.AddDays(64),
                    PriceUnder2 = 800000,
                    Price2To10 = 4500000,
                    PriceAbove10 = 6500000,
                    Latitude = 1.2897,
                    Longitude = 103.8500,
                    Address = "Marina Bay",
                    City = "Singapore",
                    Province = "Singapore"
                },
                new Product
                {
                    Name = "Tour Thái Lan - Bangkok - Pattaya 5N4Đ",
                    Description = "Khám phá xứ sở chùa vàng Thái Lan. Tham quan Wat Phra Kaew, chợ nổi Damnoen Saduak, thưởng thức ẩm thực Thái và mua sắm tại Bangkok.",
                    ImageUrl = "/images/thailand.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch nước ngoài").Id,
                    Quantity = 18,
                    StartDate = DateTime.Now.AddDays(45),
                    EndDate = DateTime.Now.AddDays(49),
                    PriceUnder2 = 600000,
                    Price2To10 = 3500000,
                    PriceAbove10 = 4800000,
                    Latitude = 13.7500,
                    Longitude = 100.5167,
                    Address = "Wat Phra Kaew",
                    City = "Bangkok",
                    Province = "Thái Lan"
                },
                new Product
                {
                    Name = "Tour Hàn Quốc - Seoul - Busan 6N5Đ",
                    Description = "Khám phá xứ sở kim chi. Tham quan cung điện Gyeongbokgung, phố Myeongdong, thưởng thức ẩm thực Hàn và trải nghiệm văn hóa K-Pop.",
                    ImageUrl = "/images/korea.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch nước ngoài").Id,
                    Quantity = 12,
                    StartDate = DateTime.Now.AddDays(70),
                    EndDate = DateTime.Now.AddDays(75),
                    PriceUnder2 = 1000000,
                    Price2To10 = 6500000,
                    PriceAbove10 = 9500000,
                    Latitude = 37.5665,
                    Longitude = 126.9780,
                    Address = "Gyeongbokgung Palace",
                    City = "Seoul",
                    Province = "Hàn Quốc"
                },
                new Product
                {
                    Name = "Tour Nhật Bản - Tokyo - Osaka 7N6Đ",
                    Description = "Khám phá đất nước mặt trời mọc. Tham quan núi Phú Sĩ, thưởng thức sushi tươi ngon, trải nghiệm văn hóa truyền thống và hiện đại của Nhật Bản.",
                    ImageUrl = "/images/japan.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch nước ngoài").Id,
                    Quantity = 10,
                    StartDate = DateTime.Now.AddDays(80),
                    EndDate = DateTime.Now.AddDays(86),
                    PriceUnder2 = 1200000,
                    Price2To10 = 8500000,
                    PriceAbove10 = 12500000,
                    Latitude = 35.6762,
                    Longitude = 139.6503,
                    Address = "Núi Phú Sĩ",
                    City = "Tokyo",
                    Province = "Nhật Bản"
                },
                new Product
                {
                    Name = "Tour Đài Loan - Taipei - Kaohsiung 5N4Đ",
                    Description = "Khám phá hòn đảo xinh đẹp Đài Loan. Tham quan tháp Taipei 101, thưởng thức ẩm thực đêm, mua sắm tại các chợ đêm nổi tiếng và trải nghiệm văn hóa địa phương.",
                    ImageUrl = "/images/taiwan.jpg",
                    CategoryId = categories.First(c => c.Name == "Du lịch nước ngoài").Id,
                    Quantity = 14,
                    StartDate = DateTime.Now.AddDays(55),
                    EndDate = DateTime.Now.AddDays(59),
                    PriceUnder2 = 700000,
                    Price2To10 = 4200000,
                    PriceAbove10 = 5800000,
                    Latitude = 25.0330,
                    Longitude = 121.5654,
                    Address = "Taipei 101",
                    City = "Taipei",
                    Province = "Đài Loan"
                },

                // NGHỈ DƯỠNG - 5 TOURS
                new Product
                {
                    Name = "Tour Nha Trang - Phú Quốc 6N5Đ",
                    Description = "Tận hưởng thiên đường biển đảo với tour nghỉ dưỡng cao cấp. Thư giãn tại các resort 5 sao, tham gia các hoạt động thể thao dưới nước, và khám phá vẻ đẹp hoang sơ của đảo ngọc Phú Quốc.",
                    ImageUrl = "/images/nhatrang-phuquoc.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour nghỉ dưỡng").Id,
                    Quantity = 12,
                    StartDate = DateTime.Now.AddDays(40),
                    EndDate = DateTime.Now.AddDays(45),
                    PriceUnder2 = 600000,
                    Price2To10 = 3500000,
                    PriceAbove10 = 4800000,
                    Latitude = 10.2737,
                    Longitude = 103.9842,
                    Address = "Bãi Sao Phú Quốc",
                    City = "Phú Quốc",
                    Province = "Kiên Giang"
                },
                new Product
                {
                    Name = "Tour Đà Nẵng - Resort 4N3Đ",
                    Description = "Nghỉ dưỡng tại resort cao cấp Đà Nẵng. Tận hưởng spa thư giãn, tham gia yoga trên bãi biển, thưởng thức buffet hải sản và thư giãn tại hồ bơi vô cực.",
                    ImageUrl = "/images/danang-resort.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour nghỉ dưỡng").Id,
                    Quantity = 20,
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(33),
                    PriceUnder2 = 450000,
                    Price2To10 = 2800000,
                    PriceAbove10 = 3800000,
                    Latitude = 16.0471,
                    Longitude = 108.2068,
                    Address = "Bãi biển Mỹ Khê",
                    City = "Đà Nẵng",
                    Province = "Đà Nẵng"
                },
                new Product
                {
                    Name = "Tour Phú Quốc - Resort Luxury 5N4Đ",
                    Description = "Nghỉ dưỡng tại resort 6 sao Phú Quốc. Villa riêng biệt với hồ bơi, spa cao cấp, thưởng thức ẩm thực quốc tế và tham gia các hoạt động thể thao dưới nước.",
                    ImageUrl = "/images/phuquoc-luxury.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour nghỉ dưỡng").Id,
                    Quantity = 8,
                    StartDate = DateTime.Now.AddDays(50),
                    EndDate = DateTime.Now.AddDays(54),
                    PriceUnder2 = 800000,
                    Price2To10 = 5500000,
                    PriceAbove10 = 7500000,
                    Latitude = 10.1641,
                    Longitude = 103.9924,
                    Address = "Vinpearl Resort Phú Quốc",
                    City = "Phú Quốc",
                    Province = "Kiên Giang"
                },
                new Product
                {
                    Name = "Tour Đà Lạt - Resort Mountain 4N3Đ",
                    Description = "Nghỉ dưỡng tại resort trên núi Đà Lạt. Tận hưởng không khí trong lành, tham gia trekking nhẹ, yoga trong rừng thông và thưởng thức ẩm thực địa phương.",
                    ImageUrl = "/images/dalat-resort.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour nghỉ dưỡng").Id,
                    Quantity = 16,
                    StartDate = DateTime.Now.AddDays(35),
                    EndDate = DateTime.Now.AddDays(38),
                    PriceUnder2 = 400000,
                    Price2To10 = 2400000,
                    PriceAbove10 = 3200000,
                    Latitude = 11.9465,
                    Longitude = 108.4419,
                    Address = "Intercontinental Dalat Resort",
                    City = "Đà Lạt",
                    Province = "Lâm Đồng"
                },
                new Product
                {
                    Name = "Tour Nha Trang - Resort Beach 5N4Đ",
                    Description = "Nghỉ dưỡng tại resort bãi biển Nha Trang. Villa biển riêng biệt, spa cao cấp, tham gia lặn biển, chèo thuyền kayak và thưởng thức cocktail tại bar bãi biển.",
                    ImageUrl = "/images/nhatrang-beach-resort.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour nghỉ dưỡng").Id,
                    Quantity = 14,
                    StartDate = DateTime.Now.AddDays(25),
                    EndDate = DateTime.Now.AddDays(29),
                    PriceUnder2 = 500000,
                    Price2To10 = 3200000,
                    PriceAbove10 = 4200000,
                    Latitude = 12.2388,
                    Longitude = 109.1967,
                    Address = "Bãi biển Nha Trang",
                    City = "Nha Trang",
                    Province = "Khánh Hòa"
                },

                // KHÁM PHÁ - 5 TOURS
                new Product
                {
                    Name = "Tour Cao Bằng - Hà Giang 4N3Đ",
                    Description = "Khám phá vùng đất địa đầu Tổ quốc với tour khám phá đầy thú vị. Ngắm nhìn những cảnh quan thiên nhiên hùng vĩ, trải nghiệm cuộc sống của các dân tộc miền núi, và chinh phục những con đèo nổi tiếng.",
                    ImageUrl = "/images/caobang-hagiang.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour khám phá").Id,
                    Quantity = 18,
                    StartDate = DateTime.Now.AddDays(25),
                    EndDate = DateTime.Now.AddDays(28),
                    PriceUnder2 = 350000,
                    Price2To10 = 1800000,
                    PriceAbove10 = 2500000,
                    Latitude = 22.8308,
                    Longitude = 104.9833,
                    Address = "Lũng Cú",
                    City = "Đồng Văn",
                    Province = "Hà Giang"
                },
                new Product
                {
                    Name = "Tour Tây Bắc - Sơn La - Điện Biên 5N4Đ",
                    Description = "Khám phá vùng Tây Bắc hoang sơ. Tham quan chiến trường Điện Biên Phủ, trải nghiệm cuộc sống các dân tộc thiểu số, ngắm ruộng bậc thang và thưởng thức ẩm thực địa phương.",
                    ImageUrl = "/images/taybac.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour khám phá").Id,
                    Quantity = 12,
                    StartDate = DateTime.Now.AddDays(40),
                    EndDate = DateTime.Now.AddDays(44),
                    PriceUnder2 = 400000,
                    Price2To10 = 2200000,
                    PriceAbove10 = 3000000,
                    Latitude = 21.3833,
                    Longitude = 103.0167,
                    Address = "Chiến trường Điện Biên Phủ",
                    City = "Điện Biên Phủ",
                    Province = "Điện Biên"
                },
                new Product
                {
                    Name = "Tour Tây Nguyên - Kon Tum - Gia Lai 4N3Đ",
                    Description = "Khám phá vùng đất Tây Nguyên đầy nắng gió. Tham quan nhà rông truyền thống, trải nghiệm cuộc sống người dân tộc, thưởng thức cà phê Tây Nguyên và ngắm cảnh hoàng hôn trên cao nguyên.",
                    ImageUrl = "/images/taynguyen.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour khám phá").Id,
                    Quantity = 15,
                    StartDate = DateTime.Now.AddDays(50),
                    EndDate = DateTime.Now.AddDays(53),
                    PriceUnder2 = 380000,
                    Price2To10 = 2000000,
                    PriceAbove10 = 2800000,
                    Latitude = 14.3540,
                    Longitude = 108.0086,
                    Address = "Nhà rông Gia Lai",
                    City = "Pleiku",
                    Province = "Gia Lai"
                },
                new Product
                {
                    Name = "Tour Nam Cát Tiên - Đồng Nai 3N2Đ",
                    Description = "Khám phá vườn quốc gia Nam Cát Tiên. Đi bộ trong rừng nguyên sinh, ngắm động vật hoang dã, tham gia tour đêm tìm culi và trải nghiệm cuộc sống sinh thái.",
                    ImageUrl = "/images/cattien.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour khám phá").Id,
                    Quantity = 20,
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(32),
                    PriceUnder2 = 320000,
                    Price2To10 = 1600000,
                    PriceAbove10 = 2200000,
                    Latitude = 11.5930,
                    Longitude = 107.3510,
                    Address = "Vườn quốc gia Nam Cát Tiên",
                    City = "Tân Phú",
                    Province = "Đồng Nai"
                },
                new Product
                {
                    Name = "Tour Côn Đảo - Khám Phá Hoang Sơ 4N3Đ",
                    Description = "Khám phá đảo Côn Đảo hoang sơ và bí ẩn. Trekking qua rừng nguyên sinh, ngắm san hô dưới biển, tham quan nhà tù lịch sử và trải nghiệm cuộc sống đảo biệt lập.",
                    ImageUrl = "/images/condao-explore.jpg",
                    CategoryId = categories.First(c => c.Name == "Tour khám phá").Id,
                    Quantity = 10,
                    StartDate = DateTime.Now.AddDays(65),
                    EndDate = DateTime.Now.AddDays(68),
                    PriceUnder2 = 550000,
                    Price2To10 = 3200000,
                    PriceAbove10 = 4200000,
                    Latitude = 8.6895,
                    Longitude = 106.6073,
                    Address = "Nhà tù Côn Đảo",
                    City = "Côn Đảo",
                    Province = "Bà Rịa - Vũng Tàu"
                }
            };
        }
    }
}
